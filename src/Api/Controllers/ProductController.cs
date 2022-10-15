using Api.Models;
using Api.Data.Dtos.Product;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		[HttpGet]
		public Microsoft.EntityFrameworkCore.DbSet<Product> Index()
		{
			return Product.GetListOfProduct();
		}

		[HttpGet("{id:int}")]
		public IActionResult Show(int id)
		{
			if (!Product.ProductExist(id))
			{
                return NotFound();
            }

            Product product = Product.GetProductById(id);
			ReadProductDto showProduct = new ReadProductDto()
			{
				Id = product.Id,
				Name = product.Name,
				Price = product.Price,
				QueryDate = DateTime.Now
			};

            return Ok(showProduct);
		}

        [HttpPost]
		public IActionResult Store([FromBody] CreateProductDto productDto)
		{
			Product product = new Product
			{
				Name  = productDto.Name,
				Price = productDto.Price
			};

			Product.AddNewProduct(product);
			return CreatedAtAction(nameof(Show), new { Id = product.Id }, product);
		}

		[HttpPut("{id:int}")]
		public IActionResult Update(int id, [FromBody] UpdateProductDto productDto)
		{
            if (!Product.ProductExist(id))
			{
				return NotFound();
			}

            Product product = Product.GetProductById(id);
            product.Name  = productDto.Name;
            product.Price = productDto.Price;
			Product.SaveChanges();

            return NoContent();
		}

		[HttpDelete("{id:int}")]
		public IActionResult Delete(int id)
		{
            if (!Product.ProductExist(id))
			{
				return NotFound();
			}

            Product product = Product.GetProductById(id);
			Product.RemoveProduct(product);

			return NoContent();
		}
	}
}

using Api.Data;
using Api.Models;
using Api.Data.Dtos.Product;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly ProductContext _productContext;

		public ProductController(ProductContext context)
		{
			_productContext = context;
        }

		[HttpGet]
		public IEnumerable<Product> Index()
		{
			return _productContext.ListOfProducts;
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

			_productContext.ListOfProducts.Add(product);
			_productContext.SaveChanges();

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
            _productContext.SaveChanges();

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
			_productContext.ListOfProducts.Remove(product);
			_productContext.SaveChanges();

			return NoContent();
		}
	}
}

using Api.Data;
using Api.Data.Dtos.ShoppingCart;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ShoppingCartController : ControllerBase
	{
		[HttpGet]
		public Microsoft.EntityFrameworkCore.DbSet<ShoppingCart> Index()
		{
			return ShoppingCart.GetListOfShoppingCart();
		}

		[HttpPost]
        public IActionResult Store([FromBody] CreateShoppingCartDto shoppingCartDto)
		{
			if (!Item.ItemExist(shoppingCartDto.ItemId))
			{
				return NotFound();
			}

            ShoppingCart cart = new ShoppingCart()
			{
				ItemId = shoppingCartDto.ItemId
			};

			ShoppingCart.AddNewShoppingCart(cart);
			return CreatedAtAction(nameof(Show), new { Id = cart.Id }, cart);
		}

		[HttpGet("{id:int}")]
		public IActionResult Show(int id)
		{
			if (!ShoppingCart.ShoppingListExist(id))
			{
                return NotFound();
			}
            
			ShoppingCart cart = ShoppingCart.GetShoppingCartById(id);
			Item item = Item.GetItemById(cart.ItemId);
			Product product = Product.GetProductById(item.ProductId);
            Promotion promotion = item.PromotionId != 0 ? Promotion.GetPromotionById(item.PromotionId) : null;

            ReadShoppingCartDto showCart = new ReadShoppingCartDto()
			{
				Id = cart.Id,
				ItemId = item.Id,
				ProductName = product.Name,
				ProductPrice = product.Price,
				PromotionName = promotion != null ? promotion.Name : "-",
				PromotionCode = promotion != null ? promotion.Code : "-",
				Quantity= item.Quantity,
				TotalValue = item.Total,
				QueryDate = DateTime.Now
			};

			return Ok(showCart);
		}

        [HttpDelete("{id:int}")]
		public IActionResult Delete(int id)
		{
            if (!ShoppingCart.ShoppingListExist(id))
            {
                return NotFound();
            }
            
            ShoppingCart cart = ShoppingCart.GetShoppingCartById(id);
			ShoppingCart.RemoveShoppingCart(cart);

            return NoContent();
        }

		[HttpPost("delete/all")]
		public IActionResult CleanShoppingList()
		{
			List<ShoppingCart> shoppingList = ShoppingCart.GetListOfShoppingCart().ToList();
			foreach (ShoppingCart cart in shoppingList)
			{
				ShoppingCart.RemoveShoppingCart(cart);
			}
			ShoppingCart.SaveChanges();
            return NoContent();
        }

		[HttpGet("Total")]
		public string GetTotalValueOfShoppingList()
		{
			double valorTotal = ShoppingCart.GetTotalValueOfShoppingCartList();
			return $"The total value of the shopping list is R$ {valorTotal}";
        }
	}
}

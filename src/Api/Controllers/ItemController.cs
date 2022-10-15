using Api.Models;
using Api.Factories;
using Api.Data.Dtos.Item;
using Api.Models.Promocoes;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ItemController : ControllerBase
    {
        [HttpGet]
        public Microsoft.EntityFrameworkCore.DbSet<Item> Index()
        {
            return Item.GetListOfItems();
        }

        [HttpGet("{id:int}")]
        public IActionResult Show(int id)
        {
            if (!Item.ItemExist(id))
            {
                return NotFound();  
            }

            Item item = Item.GetItemById(id);
            Product product = Product.GetProductById(item.ProductId);
            Promotion promotion = item.PromotionId != 0 ? Promotion.GetPromotionById(item.PromotionId) : null;

            ReadItemDto showItem = new ReadItemDto()
            {
                Id = item.Id,
                ProductId = item.ProductId,
                ProductName = product.Name,
                ProductPrice = product.Price,
                PromotionId = item.PromotionId,
                PromotionName = promotion != null ? promotion.Name : "-",
                PromotionCode = promotion != null ? promotion.Code : "-",
                Quantity = item.Quantity,
                Total = item.Total,
                QueryDate = DateTime.Now
            };

            return Ok(showItem);
        }

        [HttpPost]
        public IActionResult Store([FromBody] CreateItemDto itemDto)
        {
            if (!Product.ProductExist(itemDto.ProductId))
            {
                return NotFound();
            }

            if (itemDto.PromotionId != 0 && !Promotion.PromotionExist(itemDto.PromotionId))
            {
                return NotFound();
            }

            if (Item.ItemExistByProductId(itemDto.ProductId))
            {
                return BadRequest();
            }

            Item item = new Item
            {
                ProductId = itemDto.ProductId,
                PromotionId = itemDto.PromotionId,
                Quantity = itemDto.Quantity
            };

            Product product = Product.GetProductById(itemDto.ProductId);
            double totalValue = 0;

            if (itemDto.PromotionId != 0)
            {
                Promotion promotion = Promotion.GetPromotionById(itemDto.PromotionId);
                PromocaoFactory factory = new PromocaoFactory();
                IPromotion promotionChosed = factory.FactoryMethod(promotion.Code);
                totalValue = promotionChosed.CalculaValorTotalDaCompra(product.Price, itemDto.Quantity);
            }
            else
            {
                totalValue = product.Price * item.Quantity;
            }

            item.Total = totalValue;
            Item.AddNewItem(item);

            return CreatedAtAction(nameof(Show), new { Id = item.Id }, item);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateItemDto itemDto)
        {
            Item currentItem = Item.GetItemById(id);
            if (!Product.ProductExist(itemDto.ProductId))
            {
                return NotFound();
            }

            Product product = Product.GetProductById(itemDto.ProductId);
            if (itemDto.PromotionId != 0 && !Promotion.PromotionExist(itemDto.PromotionId))
            {
                return NotFound();
            }

            double totalValue = 0;
            Promotion promotion = itemDto.PromotionId != 0 ? Promotion.GetPromotionById(itemDto.PromotionId) : currentItem.PromotionId != 0 ? Promotion.GetPromotionById(currentItem.PromotionId) : null;
            if (promotion != null)
            {
                PromocaoFactory factory = new PromocaoFactory();
                IPromotion promotionChosed = factory.FactoryMethod(promotion.Code);
                totalValue = promotionChosed.CalculaValorTotalDaCompra(product.Price, itemDto.Quantity);
            } else
            {
                totalValue = product.Price * itemDto.Quantity;
            }

            currentItem.ProductId = itemDto.ProductId;
            currentItem.PromotionId = itemDto.PromotionId;
            currentItem.Quantity = itemDto.Quantity;
            currentItem.Total = totalValue;

            Item.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (!Item.ItemExist(id))
            {
                return NotFound();
            }

            Item item = Item.GetItemById(id);
            Item.RemoveItem(item);

            return NoContent();
        }
    }
}

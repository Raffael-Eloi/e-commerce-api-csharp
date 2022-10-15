using Api.Models;
using Api.Data.Dtos.Promotion;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        [HttpGet]
        public Microsoft.EntityFrameworkCore.DbSet<Promotion> Index()
        {
            return Promotion.GetListOfPromotions();
        }

        [HttpGet("{id:int}")]
        public IActionResult Show(int id)
        {
            if (!Promotion.PromotionExist(id))
            {
                return NotFound();
            }

            Promotion promotion = Promotion.GetPromotionById(id);
            ReadPromotionDto showPromotion = new ReadPromotionDto()
            {
                Id = promotion.Id,
                Name = promotion.Name,
                Code = promotion.Code,
                QueryDate = DateTime.Now
            };

            return Ok(showPromotion);
        }

        [HttpPost]
        public IActionResult Store([FromBody] CreatePromotionDto promotionDto)
        {
            Promotion promotion = new Promotion
            {
                Name = promotionDto.Name,
                Code = promotionDto.Code
            };

            Promotion.AddNewPromotion(promotion);
            return CreatedAtAction(nameof(Show), new { Id = promotion.Id }, promotion);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdatePromotionDto promotionDto)
        {
            if (!Promotion.PromotionExist(id))
            {
                return NotFound();
            }

            Promotion promotion = Promotion.GetPromotionById(id);
            promotion.Name = promotionDto.Name;
            promotion.Code = promotionDto.Code;

            Promotion.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (!Promotion.PromotionExist(id))
            {
                return NotFound();
            }

            Promotion promotion = Promotion.GetPromotionById(id);
            Promotion.RemovePromotion(promotion);

            return NoContent();
        }
    }
}

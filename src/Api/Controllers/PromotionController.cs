using Api.Data;
using Api.Models;
using Api.Data.Dtos.Promotion;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly PromotionContext _promotionContext;

        public PromotionController(PromotionContext context)
        {
            _promotionContext = context;
        }

        [HttpGet]
        public IEnumerable<Promotion> Index()
        {
            return _promotionContext.ListOfPromotions;
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
            _promotionContext.ListOfPromotions.Add(promotion);
            _promotionContext.SaveChanges();

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
            _promotionContext.SaveChanges();

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
            _promotionContext.ListOfPromotions.Remove(promotion);
            _promotionContext.SaveChanges();

            return NoContent();
        }
    }
}

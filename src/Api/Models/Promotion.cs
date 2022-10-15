using Api.Data;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Promotion
    {
        private static readonly PromotionContext _promotionContext;

        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [StringLength(30, ErrorMessage = "The code must to have less than 30 characters")]
        public string Code { get; set; }

        public static bool PromotionExist(int id)
        {
            Promotion promotion = _promotionContext.ListOfPromotions.FirstOrDefault(promotion => promotion.Id == id);
            return promotion != null;
        }

        public static Promotion GetPromotionById(int id)
        {
            return _promotionContext.ListOfPromotions.FirstOrDefault(promotion => promotion.Id == id);
        }
    }
}

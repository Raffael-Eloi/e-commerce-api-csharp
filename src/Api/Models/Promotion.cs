using Api.Data;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Api.Models.Promocoes;

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

        public static Microsoft.EntityFrameworkCore.DbSet<Promotion> GetListOfPromotions()
        {
            return _promotionContext.ListOfPromotions;
        }

        public static void AddNewPromotion(Promotion promotion)
        {
            _promotionContext.ListOfPromotions.Add(promotion);
            _promotionContext.SaveChanges();
        }

        public static void SaveChanges()
        {
            _promotionContext.SaveChanges();
        }

        public static void RemovePromotion(Promotion promotion)
        {
            _promotionContext.ListOfPromotions.Remove(promotion);
            _promotionContext.SaveChanges();
        }
    }
}

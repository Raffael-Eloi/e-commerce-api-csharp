using System.ComponentModel.DataAnnotations;

namespace Api.Data.Dtos.Item
{
    public class UpdateItemDto
    {
        [Required(ErrorMessage = "You must to select at least one product")]
        public int ProductId { get; set; }

        public int PromotionId { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(1, 100, ErrorMessage = "he field price must to be between 1 and 100")]
        public int Quantity { get; set; }

        [Required]
        public double Total { get; set; }
    }
}

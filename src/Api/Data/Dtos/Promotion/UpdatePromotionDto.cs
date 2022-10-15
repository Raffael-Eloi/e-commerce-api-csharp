using System.ComponentModel.DataAnnotations;

namespace Api.Data.Dtos.Promotion
{
    public class UpdatePromotionDto
    {
        [Required(ErrorMessage = "The field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [StringLength(30, ErrorMessage = "The code must to have less than 30 characters")]
        public string Code { get; set; }
    }
}

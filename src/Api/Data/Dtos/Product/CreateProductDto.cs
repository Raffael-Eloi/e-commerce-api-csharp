using System.ComponentModel.DataAnnotations;

namespace Api.Data.Dtos.Product
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "The field is required")]
        [StringLength(50, ErrorMessage = "The name must to have less than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(1, 10000, ErrorMessage = "The field price must to be between 1 and 10000")]
        public double Price { get; set; }
    }
}

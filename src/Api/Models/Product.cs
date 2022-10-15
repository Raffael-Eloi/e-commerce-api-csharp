using Api.Data;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Product
    {
        private static readonly ProductContext _productContext;

        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [StringLength(50, ErrorMessage = "The name must to have less than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(1, 10000, ErrorMessage = "The field price must to be between 1 and 10000")]
        public double Price { get; set; }

        public static bool ProductExist(int id)
        {
            Product product = _productContext.ListOfProducts.FirstOrDefault(product => product.Id == id);
            return product != null;
        }

        public static Product GetProductById(int id)
        {
            return _productContext.ListOfProducts.FirstOrDefault(product => product.Id == id);
        }
    }
}

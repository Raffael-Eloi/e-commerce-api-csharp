using System.ComponentModel.DataAnnotations;

namespace Api.Data.Dtos.ShoppingCart
{
    public class UpdateShoppingCartDto
    {
        [Required(ErrorMessage = "You must to select an item")]
        public int ItemId { get; set; }
    }
}

using Api.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Api.Models
{
    public class ShoppingCart
    {
        private static readonly ShoppingCartContext _shoppingCartContext;

        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "You must to select an item")]
        public int ItemId { get; set; }

        public static bool ShoppingListExist(int id)
        {
            ShoppingCart cart = _shoppingCartContext.ListOfShoppingCarts.FirstOrDefault(cart => cart.Id == id);
            return cart != null;
        }

        public static ShoppingCart GetShoppingCartById(int id)
        {
            return _shoppingCartContext.ListOfShoppingCarts.FirstOrDefault(cart => cart.Id == id);
        }

        public static double GetTotalValueOfShoppingCartList()
        {
            double totalValue = 0;
            List<ShoppingCart> shoppingList = _shoppingCartContext.ListOfShoppingCarts.ToList();
            foreach (ShoppingCart cart in shoppingList)
            {
                if (!Item.ItemExist(cart.ItemId))
                {
                    continue;
                }
                
                Item item = Item.GetItemById(cart.ItemId);
                totalValue += item.Total;
            }
            return totalValue;
        }
    }
}

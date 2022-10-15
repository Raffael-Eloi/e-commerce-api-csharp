using Api.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Api.Models
{
    public class Item
    {
        private static readonly ItemContext _itemContext;

        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "You must to select at least one product")]
        public int ProductId { get; set; }

        public int PromotionId { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(1, 100, ErrorMessage = "he field price must to be between 1 and 100")]
        public int Quantity { get; set; }

        [Required]
        public double Total { get; set; }

        public static bool ItemExist(int id)
        {
            Item item = _itemContext.ListOfItems.FirstOrDefault(item => item.Id == id);
            return item != null;
        }

        public static Item GetItemById(int id)
        {
            return _itemContext.ListOfItems.FirstOrDefault(item => item.Id == id);
        }

        public static bool ItemExistByProductId(int productId)
        {
            Item item = _itemContext.ListOfItems.FirstOrDefault(item => item.ProductId == productId);
            return item != null;
        }

        public static Microsoft.EntityFrameworkCore.DbSet<Item> GetListOfItems()
        {
            return _itemContext.ListOfItems;
        }

        public static void AddNewItem(Item item)
        {
            _itemContext.ListOfItems.Add(item);
            _itemContext.SaveChanges();
        }

        public static void SaveChanges()
        {
            _itemContext.SaveChanges();
        }

        public static void RemoveItem(Item item)
        {
            _itemContext.ListOfItems.Remove(item);
            _itemContext.SaveChanges();
        }
    }
}
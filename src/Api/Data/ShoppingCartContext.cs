using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> opt) : base(opt)
        {

        }

        public DbSet<ShoppingCart> ListOfShoppingCarts { get; set; }
    }
}

using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> opt) : base(opt)
        {

        }

        public DbSet<Product> ListOfProducts { get; set; }
    }
}

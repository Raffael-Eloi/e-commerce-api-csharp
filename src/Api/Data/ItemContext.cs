using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> opt) : base(opt)
        {

        }

        public DbSet<Item> ListOfItems { get; set; }
    }
}

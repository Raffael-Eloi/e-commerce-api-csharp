using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class PromotionContext : DbContext
    {
        public PromotionContext(DbContextOptions<PromotionContext> opt) : base(opt)
        {

        }

        public DbSet<Promotion> ListOfPromotions { get; set; }
    }
}

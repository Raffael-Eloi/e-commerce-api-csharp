using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class PromocaoContext : DbContext
    {
        public PromocaoContext(DbContextOptions<PromocaoContext> opt) : base(opt)
        {

        }

        public DbSet<Promocao> Promocoes { get; set; }
    }
}

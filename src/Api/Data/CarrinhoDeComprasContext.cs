using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class CarrinhoDeComprasContext : DbContext
    {
        public CarrinhoDeComprasContext(DbContextOptions<CarrinhoDeComprasContext> opt) : base(opt)
        {

        }

        public DbSet<CarrinhoDeCompras> CarrinhoDeCompras { get; set; }
    }
}

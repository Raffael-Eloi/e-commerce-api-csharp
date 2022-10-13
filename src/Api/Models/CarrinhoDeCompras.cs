using Api.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Api.Models
{
    public class CarrinhoDeCompras
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "É obrigatório vincular o item ao carrinho")]
        public int IdDoItem { get; set; }

        public static bool CarrinhoExiste(CarrinhoDeComprasContext carrinhoContext, int id)
        {
            CarrinhoDeCompras carrinho = carrinhoContext.CarrinhoDeCompras.FirstOrDefault(carrinho => carrinho.Id == id);
            return carrinho != null;
        }

        public static CarrinhoDeCompras RecuperarCarrinhoPeloId(CarrinhoDeComprasContext carrinhoContext, int id)
        {
            return carrinhoContext.CarrinhoDeCompras.FirstOrDefault(carrinho => carrinho.Id == id);
        }

        public static double ObterTotalDoCarrinhoDeCompras(CarrinhoDeComprasContext carrinhoContext, ItemContext itemContext)
        {
            double valorTotal = 0;
            List<CarrinhoDeCompras> listaDeCompras = carrinhoContext.CarrinhoDeCompras.ToList();
            foreach (CarrinhoDeCompras carrinho in listaDeCompras)
            {
                if (!Item.ItemExiste(itemContext, carrinho.IdDoItem))
                {
                    continue;
                }
                
                Item item = Item.RecuperarItemPeloId(itemContext, carrinho.IdDoItem);
                valorTotal += item.valorTotal;
            }
            return valorTotal;
        }
    }
}

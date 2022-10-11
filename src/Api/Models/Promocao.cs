using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Promocao
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da promoção é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O código da promoção é obrigatório")]
        public string Codigo{ get; set; }

        public static double calculaValorDoItem(Item item, Produto produto, Promocao promocao)
        {
            if (promocao.Codigo == "3por10")
            {
                if (item.Quantidade == 3)
                {
                    return 30.0;
                }
            } else if (promocao.Codigo == "leve2page1")
            {
                if (item.Quantidade >= 2)
                {
                    return (double) ((produto.Preco * item.Quantidade) - produto.Preco);
                }
            }

            return (double) produto.Preco * item.Quantidade;
        }
    }
}

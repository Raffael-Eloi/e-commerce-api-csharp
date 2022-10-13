using Api.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        public static bool PromocaoExiste(PromocaoContext promocaoContext, int id)
        {
            Promocao promocao = promocaoContext.Promocoes.FirstOrDefault(promocao => promocao.Id == id);
            return promocao != null;
        }

        public static Promocao RecuperarPromocaoPeloId(PromocaoContext promocaoContext, int id)
        {
            return promocaoContext.Promocoes.FirstOrDefault(promocao => promocao.Id == id);
        }
    }
}

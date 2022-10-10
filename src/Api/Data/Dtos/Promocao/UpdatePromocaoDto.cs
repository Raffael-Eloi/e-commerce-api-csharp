using System.ComponentModel.DataAnnotations;

namespace Api.Data.Dtos.Promocao
{
    public class UpdatePromocaoDto
    {
        [Required(ErrorMessage = "O nome da promoção é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O código da promoção é obrigatório")]
        public string Codigo { get; set; }
    }
}

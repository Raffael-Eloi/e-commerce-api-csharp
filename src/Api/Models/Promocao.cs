using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Promocao
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da promoção é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O código da promoção é obrigatório")]
        public string Código{ get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Model
{
    public class Produto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(50, ErrorMessage = "O nome não pode passar de 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo preço é obrigatório")]
        [Range(1,1000000, ErrorMessage = "O campo nome é obrigatório")]
        public decimal Preco { get; set; }
    }
}

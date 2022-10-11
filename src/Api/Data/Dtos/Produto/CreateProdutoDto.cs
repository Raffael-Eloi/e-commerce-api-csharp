using System.ComponentModel.DataAnnotations;

namespace Api.Data.Dtos.Produto
{
    public class CreateProdutoDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(50, ErrorMessage = "O nome não pode passar de 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo preço é obrigatório")]
        [Range(1, 1000000, ErrorMessage = "O preço deve ser maior que 1 e menor que 1000000")]
        public decimal Preco { get; set; }
    }
}

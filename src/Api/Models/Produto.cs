using Api.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Api.Models
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

        public static bool ProdutoExiste(ProdutoContext produtoContext, int id)
        {
            Produto produto = produtoContext.Produtos.FirstOrDefault(produto => produto.Id == id);
            return produto == null;
        }

        public static Produto RecuperarProdutoPeloId(ProdutoContext produtoContext, int id)
        {
            return produtoContext.Produtos.FirstOrDefault(produto => produto.Id == id);
        }
    }
}

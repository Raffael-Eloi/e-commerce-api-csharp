using System.ComponentModel.DataAnnotations;

namespace Api.Data.Dtos.CarrinhoDeCompras
{
    public class CreateCarrinhoDeComprasDto
    {
        [Required(ErrorMessage = "É obrigatório vincular o item ao carrinho")]
        public int IdDoItem { get; set; }
    }
}

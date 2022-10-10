using Api.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class CarrinhoDeCompras
    {
        [Key]
        [Required]
        public int Id { get; set; }


        [Required(ErrorMessage = "É obrigatório vincular o item ao carrinho")]
        public int IdDoItem { get; set; }
    }
}

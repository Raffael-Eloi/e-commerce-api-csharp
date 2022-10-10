using System.ComponentModel.DataAnnotations;

namespace Api.Data.Dtos.Item
{
    public class UpdateItemDto
    {
        [Required(ErrorMessage = "É obrigatório selecionar o menos 1 produto")]
        public int IdDoProduto { get; set; }

        public int IdDaPromocao { get; set; }

        [Required(ErrorMessage = "É obrigatório definir a quantidade")]
        [Range(1, 100, ErrorMessage = "A quantidade dever ser no mínimo 1 e no máximo 100")]
        public int Quantidade { get; set; }
    }
}

using Api.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Api.Models
{
    public class Item
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "É obrigatório selecionar o menos 1 produto")]
        public int IdDoProduto { get; set; }

        public int IdDaPromocao { get; set; }

        [Required(ErrorMessage = "É obrigatório definir a quantidade")]
        [Range(1, 100, ErrorMessage = "A quantidade dever ser no mínimo 1 e no máximo 100")]
        public int Quantidade { get; set; }

        [Required]
        public double valorTotal { get; set; }

        public static bool ItemExiste(ItemContext itemContext, int id)
        {
            Item item = itemContext.Items.FirstOrDefault(item => item.Id == id);
            return item != null;
        }

        public static Item RecuperarItemPeloId(ItemContext itemContext, int id)
        {
            return itemContext.Items.FirstOrDefault(item => item.Id == id);
        }
    }
}
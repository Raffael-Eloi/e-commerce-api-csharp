using Api.Data.Dtos.Promocao;
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Api.Model;
using System.Linq;
using Api.Data.Dtos.Item;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ItemController : ControllerBase
    {

        private ItemContext _itemContext;

        public ItemController(ItemContext context)
        {
            _itemContext = context;
        }

        [HttpGet]
        public IEnumerable<Item> TodosOsItens()
        {
            return _itemContext.Items;
        }

        [HttpGet("{id:int}")]
        public IActionResult Detalhes(int id)
        {
            Item item = _itemContext.Items.FirstOrDefault(item => item.Id == id);
            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult NovoItem([FromBody] CreateItemDto itemDto)
        {
            Item item = new Item
            {
                IdDoProduto = itemDto.IdDoProduto,
                IdDaPromocao = itemDto.IdDaPromocao,
                Quantidade = itemDto.Quantidade
            };
            _itemContext.Items.Add(item);
            _itemContext.SaveChanges();

            return CreatedAtAction(nameof(Detalhes), new { Id = item.Id }, item);
        }

        [HttpPut("{id:int}")]
        public IActionResult EditarItem(int id, [FromBody] UpdateItemDto itemDto)
        {
            Item item = _itemContext.Items.FirstOrDefault(item => item.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            item.IdDoProduto = itemDto.IdDoProduto;
            item.IdDaPromocao = itemDto.IdDaPromocao;
            item.Quantidade = itemDto.Quantidade;

            _itemContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult ExcluirItem(int id)
        {
            Item item = _itemContext.Items.FirstOrDefault(item => item.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            _itemContext.Items.Remove(item);
            _itemContext.SaveChanges();

            return NoContent();
        }
    }
}

using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Api.Data.Dtos.Item;
using Api.Factories;
using Api.Models.Promocoes;
using System;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ItemController : ControllerBase
    {
        private ItemContext _itemContext;
        private ProductContext _produtoContext;
        private PromocaoContext _promocaoContext;

        public ItemController(ItemContext context, ProductContext produtoContext, PromocaoContext promocaoContext)
        {
            _itemContext = context;
            _produtoContext = produtoContext;
            _promocaoContext = promocaoContext;
        }

        [HttpGet]
        public IEnumerable<Item> TodosOsItens()
        {
            return _itemContext.Items;
        }

        [HttpGet("{id:int}")]
        public IActionResult Detalhes(int id)
        {
            if (!Item.ItemExiste(_itemContext, id))
            {
                return NotFound();  
            }

            Item item = Item.RecuperarItemPeloId(_itemContext, id);
            Product produto = Product.RecuperarProdutoPeloId(_produtoContext, item.IdDoProduto);
            Console.WriteLine(Promocao.RecuperarPromocaoPeloId(_promocaoContext, item.IdDaPromocao).Nome);
            Promocao promocao = item.IdDaPromocao != 0 ? Promocao.RecuperarPromocaoPeloId(_promocaoContext, item.IdDaPromocao) : null;

            ReadItemDto itemVisualizacao = new ReadItemDto()
            {
                Id = item.Id,
                IdDoProduto = item.IdDoProduto,
                NomeDoProduto = produto.Nome,
                PrecoDoProduto = produto.Preco,
                IdDaPromocao = item.IdDaPromocao,
                NomeDaPromocao = promocao != null ? promocao.Nome : "-",
                CodigoDaPromocao = promocao != null ? promocao.Codigo : "-",
                Quantidade = item.Quantidade,
                valorTotal = item.valorTotal,
                HoraDaConsulta = DateTime.Now
            };

            return Ok(itemVisualizacao);
        }

        [HttpPost]
        public IActionResult NovoItem([FromBody] CreateItemDto itemDto)
        {
            if (Product.ProdutoExiste(_produtoContext, itemDto.IdDoProduto))
            {
                return NotFound();
            }

            if (Promocao.PromocaoExiste(_promocaoContext, itemDto.IdDaPromocao))
            {
                return NotFound();
            }

            Product produto = Product.RecuperarProdutoPeloId(_produtoContext, itemDto.IdDoProduto); 
            Item itemVerificacao = _itemContext.Items.FirstOrDefault(itemVerificacao => itemVerificacao.IdDoProduto == itemDto.IdDoProduto);
            if (itemVerificacao != null)
            {
                return BadRequest();
            }

            Item item = new Item
            {
                IdDoProduto = itemDto.IdDoProduto,
                IdDaPromocao = itemDto.IdDaPromocao,
                Quantidade = itemDto.Quantidade
            };

            double valorTotal = 0;
            if (itemDto.IdDaPromocao != 0)
            {
                Promocao promocao = Promocao.RecuperarPromocaoPeloId(_promocaoContext, itemDto.IdDaPromocao);
                PromocaoFactory factory = new PromocaoFactory();
                IPromotion promocaoEscolhida = factory.FactoryMethod(promocao.Codigo);
                valorTotal = promocaoEscolhida.CalculaValorTotalDaCompra(produto.Preco, itemDto.Quantidade);
            }
            else
            {
                valorTotal = (double)produto.Preco * item.Quantidade;
            }

            item.valorTotal = valorTotal;
            _itemContext.Items.Add(item);
            _itemContext.SaveChanges();

            return CreatedAtAction(nameof(Detalhes), new { Id = item.Id }, item);
        }

        [HttpPut("{id:int}")]
        public IActionResult EditarItem(int id, [FromBody] UpdateItemDto itemDto)
        {
            Item itemAtual = Item.RecuperarItemPeloId(_itemContext, id);
            if (!Product.ProdutoExiste(_produtoContext, itemDto.IdDoProduto))
            {
                return NotFound();
            }

            Product produto = Product.RecuperarProdutoPeloId(_produtoContext, itemDto.IdDoProduto);
            if (itemDto.IdDaPromocao != 0 && !Promocao.PromocaoExiste(_promocaoContext, itemDto.IdDaPromocao))
            {
                return NotFound();
            }

            double valorTotal = 0;
            Promocao promocao = itemDto.IdDaPromocao != 0 ? Promocao.RecuperarPromocaoPeloId(_promocaoContext, itemDto.IdDaPromocao) : itemAtual.IdDaPromocao != 0 ? Promocao.RecuperarPromocaoPeloId(_promocaoContext, itemAtual.IdDaPromocao) : null;
            if (promocao != null)
            {
                PromocaoFactory factory = new PromocaoFactory();
                IPromotion promocaoEscolhida = factory.FactoryMethod(promocao.Codigo);
                valorTotal = promocaoEscolhida.CalculaValorTotalDaCompra(produto.Preco, itemDto.Quantidade);
            } else
            {
                valorTotal = (double) produto.Preco * itemDto.Quantidade;
            }

            itemAtual.IdDoProduto = itemDto.IdDoProduto;
            itemAtual.IdDaPromocao = itemDto.IdDaPromocao;
            itemAtual.Quantidade = itemDto.Quantidade;
            itemAtual.valorTotal = valorTotal;

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

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
        private ProdutoContext _produtoContext;
        private PromocaoContext _promocaoContext;

        public ItemController(ItemContext context, ProdutoContext produtoContext, PromocaoContext promocaoContext)
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
            Item item = _itemContext.Items.FirstOrDefault(item => item.Id == id);
            if (item == null)
            {
                return NotFound();  
            }

            Produto produto = Produto.RecuperarProdutoPeloId(_produtoContext, item.IdDoProduto);
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
            if (Produto.ProdutoExiste(_produtoContext, itemDto.IdDoProduto))
            {
                return NotFound();
            }

            if (Promocao.PromocaoExiste(_promocaoContext, itemDto.IdDaPromocao))
            {
                return NotFound();
            }

            Produto produto = Produto.RecuperarProdutoPeloId(_produtoContext, itemDto.IdDoProduto); 
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
            Produto produto = _produtoContext.Produtos.FirstOrDefault(produto => produto.Id == itemDto.IdDoProduto);
            if (produto == null)
            {
                return NotFound();
            }

            Item item = _itemContext.Items.FirstOrDefault(item => item.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            Promocao promocao = _promocaoContext.Promocoes.FirstOrDefault(promocao => promocao.Id == itemDto.IdDaPromocao);
            if (itemDto.IdDaPromocao != 0 && promocao == null)
            {
                return NotFound();
            }

            double valorTotal = 0;
            if (promocao != null)
            {
                PromocaoFactory factory = new PromocaoFactory();
                IPromotion promocaoEscolhida = factory.FactoryMethod(promocao.Codigo);
                valorTotal = promocaoEscolhida.CalculaValorTotalDaCompra(produto.Preco, itemDto.Quantidade);
            } else
            {
                valorTotal = (double) produto.Preco * item.Quantidade;
            }

            item.IdDoProduto = itemDto.IdDoProduto;
            item.IdDaPromocao = itemDto.IdDaPromocao;
            item.Quantidade = itemDto.Quantidade;
            item.valorTotal = valorTotal;

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

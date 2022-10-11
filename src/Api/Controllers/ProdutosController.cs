using Api.Data;
using Api.Data.Dtos.Produto;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProdutosController : ControllerBase
	{
		private readonly ProdutoContext _produtoContext;

		public ProdutosController(ProdutoContext context)
		{
			_produtoContext = context;
        }

		[HttpGet]
		public IEnumerable<Produto> TodosOsProdutos()
		{
			return _produtoContext.Produtos;
		}

		[HttpGet("{id:int}")]
		public IActionResult Detalhes(int id)
		{
			if (!Produto.ProdutoExiste(_produtoContext, id))
			{
                return NotFound();
            }
            Produto produto = Produto.RecuperarProdutoPeloId(_produtoContext, id);
            return Ok(produto);
		}

        [HttpPost]
		public IActionResult NovoProduto([FromBody] CreateProdutoDto produtoDto)
		{
			Produto produto = new Produto
			{
				Nome  = produtoDto.Nome,
				Preco = produtoDto.Preco
			};

			_produtoContext.Produtos.Add(produto);
			_produtoContext.SaveChanges();

			return CreatedAtAction(nameof(Detalhes), new { Id = produto.Id }, produto);
		}

		[HttpPut("{id:int}")]
		public IActionResult EditarProduto(int id, [FromBody] UpdateProdutoDto produtoDto)
		{
            if (!Produto.ProdutoExiste(_produtoContext, id))
			{
				return NotFound();
			}

            Produto produto = Produto.RecuperarProdutoPeloId(_produtoContext, id);
			produto.Nome  = produtoDto.Nome;
            produto.Preco = produtoDto.Preco;
            _produtoContext.SaveChanges();

            return NoContent();
		}

		[HttpDelete("{id:int}")]
		public IActionResult ExcluirProduto(int id)
		{
            if (!Produto.ProdutoExiste(_produtoContext, id))
			{
				return NotFound();
			}

            Produto produto = Produto.RecuperarProdutoPeloId(_produtoContext, id);	
			_produtoContext.Produtos.Remove(produto);
			_produtoContext.SaveChanges();

			return NoContent();
		}
	}
}

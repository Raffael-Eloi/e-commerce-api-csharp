using Api.Data;
using Api.Data.Dtos.Produto;
using Api.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProdutosController : ControllerBase
	{
		private ProdutoContext _produtoContext;

		public ProdutosController(ProdutoContext context)
		{
			_produtoContext = context;
        }

        [HttpPut("{idDoProduto}/Promocao/{idDaPromocao}")]
		public void VincularPromocaoAoProduto(int idDaPromocao, int idDoProduto)
		{
		}

		[HttpGet]
		public IEnumerable<Produto> TodosOsProdutos()
		{
			return _produtoContext.Produtos;
		}

		[HttpGet("{id:int}")]
		public IActionResult Detalhes(int id)
		{
			Produto produto = _produtoContext.Produtos.FirstOrDefault(produto => produto.Id == id);
			if (produto != null)
			{
				return Ok(produto);
			}

			return NotFound();
		}

		[HttpPost]
		public IActionResult NovoProduto([FromBody] CreateProdutoDto produtoDto)
		{
			Produto produto = new Produto
			{
				Nome = produtoDto.Nome,
				Preco = produtoDto.Preco
			};
			_produtoContext.Produtos.Add(produto);
			_produtoContext.SaveChanges();

			return CreatedAtAction(nameof(Detalhes), new { Id = produto.Id }, produto);
		}

		[HttpPut("{id:int}")]
		public IActionResult EditarProduto(int id, [FromBody] UpdateProduto produtoDto)
		{
			Produto produto = _produtoContext.Produtos.FirstOrDefault(produto => produto.Id == id);
			
			if (produto == null)
			{
				return NotFound();
			}

            produto.Preco = produtoDto.Preco;
            produto.Nome = produtoDto.Nome;
			_produtoContext.SaveChanges();

            return NoContent();
		}

		[HttpDelete("{id:int}")]
		public IActionResult ExcluirProduto(int id)
		{
			Produto produto = _produtoContext.Produtos.FirstOrDefault(produto => produto.Id == id);
			if (produto == null)
			{
				return NotFound();
			}
			_produtoContext.Produtos.Remove(produto);
			_produtoContext.SaveChanges();

			return NoContent();
		}
	}
}

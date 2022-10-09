using Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProdutosController : ControllerBase
	{
        private static readonly string nomeArquivoCSV = "Repositorio\\produtos.csv";

        [HttpPut("{idDoProduto}/Promocao/{idDaPromocao}")]
		public void VincularPromocaoAoProduto(int idDaPromocao, int idDoProduto)
		{
		}

		[HttpGet("todos")]
		public string TodosOsProdutos()
		{
			return "Aqui vai ser o get all";
		}

		[HttpGet("detalhes/{id:int}")]
		public string Detalhes(int id)
		{
			return $"Aqui vai ser o get do produto do id {id}";
		}

		[HttpPost("novo")]
		public string NovoProduto()
		{
			Console.WriteLine(HttpContext.Request.Form["nome"].ToString());
			//var nome = HttpContext.Request.Form["nome"].ToString();
			//var preco = HttpContext.Request.Form["preco"].ToString();

			//file.WriteLine($"${Produto.Id};{Produto.Nome};{Produto.Preco}");
			//return $"{nome} - {preco}";

			Produto produto = new Produto(Produto.getLastId(), "Produto teste", 525);
			Produto.insereNovoProduto(produto);

			Response.StatusCode = 201;
			return $"{produto.Nome} foi cadastrado com sucesso";
		}

		[HttpPut("editar/{id:int}")]
		public string EditarProduto(int id)
		{
			return $"Aqui vai ser o editar do produto do id {id}";
		}

		[HttpDelete("excluir/{id:int}")]
		public string ExcluirProduto(int id)
		{
			return $"Aqui vai ser o excluir do produto do id {id}";
		}
	}
}

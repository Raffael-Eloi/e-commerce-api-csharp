using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProdutosController : ControllerBase
	{
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
			return "Aqui vai criar um novo Produto";
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

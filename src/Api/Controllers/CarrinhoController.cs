using Api.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CarrinhoController : ControllerBase
	{
		private static readonly List<Produto> _produtos = new List<Produto>
		{
			//new Produto ( 1, "PS5", 50 ),
			//new Produto ( 2, "TV do Edi 32 polegadas (Modelo 2002)", 30 ),
			//new Produto ( 3, "Sanfona do Buxin", 10 )
		};

		[HttpGet("todos")]
		public string TodosOsItens()
		{
			return "Aqui vai retornar todos os itens do carrinho";
		}

		[HttpPost("novo")]
        //public string AdicionarItem(Item item)
        public string AdicionarItem()
		{
			return "Aqui vai cadastrar um novo item no carrinho";
		}

		[HttpDelete("excluir/{id:int}")]
		public string ExcluirItemDoCarrinho(int id)
		{
			return $"Aqui vai excluir o carrinho com o produto do id {id}";
		}

		[HttpPost("limpar-carrinho")]
		public string LimparCarrinho()
		{
			return "Aqui vai limpar o carrinho";
		}

		[HttpGet("Total")]
		public decimal ObterTotalDoCarrinho()
		{
			return 0;
		}
	}
}

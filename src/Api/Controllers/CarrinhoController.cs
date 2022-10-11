using Api.Data;
using Api.Data.Dtos.CarrinhoDeCompras;
using Api.Model;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CarrinhoController : ControllerBase
	{
		private CarrinhoDeComprasContext _carrinhoContext;
        private ItemContext _itemContext;
        private ProdutoContext _produtoContext;

        public CarrinhoController(CarrinhoDeComprasContext carrinhoContext, ItemContext itemContext, ProdutoContext produtoContext)
		{
			_carrinhoContext = carrinhoContext;
			_itemContext = itemContext;
			_produtoContext = produtoContext;
        }

		[HttpGet]
		public IEnumerable<CarrinhoDeCompras> Todos()
		{
			return _carrinhoContext.CarrinhoDeCompras;
		}

		[HttpPost]
        public IActionResult AdicionarItemNoCarrinho([FromBody] CreateCarrinhoDeComprasDto carrinhoDeComprasDto)
		{
            Item item = _itemContext.Items.FirstOrDefault(item => item.Id == carrinhoDeComprasDto.IdDoItem);
			if (item == null)
			{
				return NotFound();
			}

            CarrinhoDeCompras carrinho = new CarrinhoDeCompras()
			{
				IdDoItem = carrinhoDeComprasDto.IdDoItem
			};

			_carrinhoContext.CarrinhoDeCompras.Add(carrinho);
			_carrinhoContext.SaveChanges();

			return CreatedAtAction(nameof(Detalhes), new { Id = carrinho.Id }, carrinho);
		}

		[HttpGet("{id:int}")]
		public IActionResult Detalhes(int id)
		{
			CarrinhoDeCompras carrinho = _carrinhoContext.CarrinhoDeCompras.FirstOrDefault(carrinho => carrinho.Id == id);
			if (carrinho != null)
			{
				return Ok(carrinho);
			}
			return NotFound();
		}

        [HttpDelete("{id:int}")]
		public IActionResult ExcluirItemDoCarrinho(int id)
		{
            CarrinhoDeCompras carrinho = _carrinhoContext.CarrinhoDeCompras.FirstOrDefault(carrinho => carrinho.Id == id);
            if (carrinho == null)
            {
                return NotFound();
            }
            
            _carrinhoContext.Remove(carrinho);
            _carrinhoContext.SaveChanges();
            return NoContent();
        }

		[HttpPost("limpar-carrinho")]
		public IActionResult LimparCarrinho()
		{
			List<CarrinhoDeCompras> listOfCompras = _carrinhoContext.CarrinhoDeCompras.ToList();
			foreach (var carrinho in listOfCompras)
			{
                _carrinhoContext.CarrinhoDeCompras.Remove(carrinho);
			}
            _carrinhoContext.SaveChanges();
            return NoContent();
        }

		[HttpGet("Total")]
		public string ObterTotalDoCarrinho()
		{
			double valorTotal = 0;
            List<CarrinhoDeCompras> listOfCompras = _carrinhoContext.CarrinhoDeCompras.ToList();
            foreach (var carrinho in listOfCompras)
            {
				Item item = _itemContext.Items.FirstOrDefault(item => item.Id == carrinho.IdDoItem);
				Produto produto = _produtoContext.Produtos.FirstOrDefault(produto => produto.Id == item.IdDoProduto);

                valorTotal += item.valorTotal;
            }

			return $"O valor total do carrinho é {valorTotal}";
        }
	}
}

using Api.Data;
using Api.Data.Dtos.CarrinhoDeCompras;
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
			if (!Item.ItemExiste(_itemContext, carrinhoDeComprasDto.IdDoItem))
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
			if (!CarrinhoDeCompras.CarrinhoExiste(_carrinhoContext, id))
			{
                return NotFound();
			}
            CarrinhoDeCompras carrinho = CarrinhoDeCompras.RecuperarCarrinhoPeloId(_carrinhoContext, id);
			return Ok(carrinho);
		}

        [HttpDelete("{id:int}")]
		public IActionResult ExcluirItemDoCarrinho(int id)
		{
            if (!CarrinhoDeCompras.CarrinhoExiste(_carrinhoContext, id))
            {
                return NotFound();
            }
            
            CarrinhoDeCompras carrinho = CarrinhoDeCompras.RecuperarCarrinhoPeloId(_carrinhoContext, id);
            _carrinhoContext.Remove(carrinho);
            _carrinhoContext.SaveChanges();
            return NoContent();
        }

		[HttpPost("limpar-carrinho")]
		public IActionResult LimparCarrinho()
		{
			List<CarrinhoDeCompras> listOfCompras = _carrinhoContext.CarrinhoDeCompras.ToList();
			foreach (CarrinhoDeCompras carrinho in listOfCompras)
			{
                _carrinhoContext.CarrinhoDeCompras.Remove(carrinho);
			}
            _carrinhoContext.SaveChanges();
            return NoContent();
        }

		[HttpGet("Total")]
		public string ObterTotalDoCarrinho()
		{
			double valorTotal = CarrinhoDeCompras.ObterTotalDoCarrinhoDeCompras(_carrinhoContext, _itemContext);
			return $"O valor total do carrinho é {valorTotal}";
        }
	}
}

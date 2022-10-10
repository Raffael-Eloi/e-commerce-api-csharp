using Api.Data;
using Api.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Api.Models;
using System.Linq;
using Api.Data.Dtos.Produto;
using Api.Data.Dtos.Promocao;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocaoController : ControllerBase
    {

        private PromocaoContext _promocaoContext;

        public PromocaoController(PromocaoContext context)
        {
            _promocaoContext = context;
        }

        [HttpGet]
        public IEnumerable<Promocao> TodosAsPromocoes()
        {
            return _promocaoContext.Promocoes;
        }

        [HttpGet("{id:int}")]
        public IActionResult Detalhes(int id)
        {
            Promocao promocao = _promocaoContext.Promocoes.FirstOrDefault(promocao => promocao.Id == id);
            if (promocao != null)
            {
                return Ok(promocao);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult NovaPromocao([FromBody] CreatePromocaoDto promocaoDto)
        {
            Promocao produto = new Promocao
            {
                Nome = promocaoDto.Nome,
                Codigo = promocaoDto.Codigo
            };
            _promocaoContext.Promocoes.Add(produto);
            _promocaoContext.SaveChanges();

            return CreatedAtAction(nameof(Detalhes), new { Id = produto.Id }, produto);
        }

        [HttpPut("{id:int}")]
        public IActionResult EditarPromocao(int id, [FromBody] UpdatePromocaoDto promocaoDto)
        {
            Promocao promocao = _promocaoContext.Promocoes.FirstOrDefault(promocao => promocao.Id == id);

            if (promocao == null)
            {
                return NotFound();
            }

            promocao.Nome = promocaoDto.Nome;
            promocao.Codigo = promocaoDto.Codigo;
            _promocaoContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult ExcluirPromocao(int id)
        {
            Promocao promocao = _promocaoContext.Promocoes.FirstOrDefault(promocao => promocao.Id == id);
            if (promocao == null)
            {
                return NotFound();
            }
            _promocaoContext.Promocoes.Remove(promocao);
            _promocaoContext.SaveChanges();

            return NoContent();
        }

    }
}

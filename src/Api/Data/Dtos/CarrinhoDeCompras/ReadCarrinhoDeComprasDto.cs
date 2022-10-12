using System;
namespace Api.Data.Dtos.CarrinhoDeCompras
{
    public class ReadCarrinhoDeComprasDto
    {
        public int Id { get; set; }

        public int IdDoItem { get; set; }

        public string NomeDoProduto { get; set; }

        public double PrecoDoProduto { get; set; }

        public string NomeDaPromocao { get; set; }

        public string CodigoDaPromocao { get; set; }

        public int Quantidade { get; set; }

        public double ValorTotal { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}

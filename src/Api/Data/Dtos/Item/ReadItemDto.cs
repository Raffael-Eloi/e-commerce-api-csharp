using System;
namespace Api.Data.Dtos.Item
{
    public class ReadItemDto
    {
        public int Id { get; set; }

        public int IdDoProduto { get; set; }

        public string NomeDoProduto { get; set; }

        public double PrecoDoProduto { get; set; }

        public int IdDaPromocao { get; set; }

        public string NomeDaPromocao { get; set; }

        public string CodigoDaPromocao { get; set; }

        public int Quantidade { get; set; }

        public double valorTotal { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}

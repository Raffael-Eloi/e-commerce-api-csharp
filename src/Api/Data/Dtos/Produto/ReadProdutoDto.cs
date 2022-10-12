using System;

namespace Api.Data.Dtos.Produto
{
    public class ReadProdutoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public double Preco { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}

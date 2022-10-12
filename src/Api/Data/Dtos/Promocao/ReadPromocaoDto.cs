using System;
namespace Api.Data.Dtos.Promocao
{
    public class ReadPromocaoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Codigo { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}

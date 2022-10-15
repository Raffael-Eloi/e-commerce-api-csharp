using System;

namespace Api.Data.Dtos.Product
{
    public class ReadProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public DateTime QueryDate { get; set; }
    }
}

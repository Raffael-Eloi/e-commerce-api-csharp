using System;
namespace Api.Data.Dtos.Promotion
{
    public class ReadPromotionDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime QueryDate { get; set; }
    }
}

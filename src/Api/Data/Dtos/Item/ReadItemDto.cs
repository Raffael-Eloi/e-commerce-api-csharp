using System;
namespace Api.Data.Dtos.Item
{
    public class ReadItemDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public int PromotionId { get; set; }

        public string PromotionName { get; set; }

        public string PromotionCode { get; set; }

        public int Quantity { get; set; }

        public double Total { get; set; }

        public DateTime QueryDate { get; set; }
    }
}

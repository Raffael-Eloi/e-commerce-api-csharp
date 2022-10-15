using System;
namespace Api.Data.Dtos.ShoppingCart
{
    public class ReadShoppingCartDto
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public string PromotionName { get; set; }

        public string PromotionCode { get; set; }

        public int Quantity { get; set; }

        public double TotalValue { get; set; }

        public DateTime QueryDate { get; set; }
    }
}

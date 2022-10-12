namespace Api.Models.Promocoes
{
    public class TresPorDez : IPromotion
    {
        public double CalculaValorTotalDaCompra(double valorProduto, int quantidade)
        {
            if (quantidade != 3)
            {
                return quantidade * valorProduto;
            }

            return 30;
        }
    }
}

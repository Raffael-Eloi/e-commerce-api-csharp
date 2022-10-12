namespace Api.Models.Promocoes
{
    public class LeveDoisPagueUm : IPromotion
    {
        public double CalculaValorTotalDaCompra(double valorProduto, int quantidade)
        {
            if (quantidade != 2)
            {
                return valorProduto * quantidade;
            }

            return valorProduto;
        }
    }
}

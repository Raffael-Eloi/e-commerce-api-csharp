namespace Api.Models.Promocoes
{
    public interface IPromotion
    {
        public double CalculaValorTotalDaCompra(double valorProduto, int quantidade);
    }
}

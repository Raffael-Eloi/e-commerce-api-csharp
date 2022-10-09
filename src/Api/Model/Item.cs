namespace Api.Model
{
    public class Item
    {
        public int IdDoProduto { get; set; }
        public int Quantidade { get; set; }

        public Item(int idDoProduto, int quantidade)
        {
            IdDoProduto = idDoProduto;
            Quantidade = quantidade;
        }
    }
}
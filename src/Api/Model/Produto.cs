using Api.Repositorio;
using System;
using System.IO;

namespace Api.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public Produto(int id, string nome, decimal preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }

        public static int getLastId()
        {
            int lastId = -1;
            using (var file = File.OpenText(ProdutoRepositorioFake.nomeArquivoCSV))
            {
                while (!file.EndOfStream)
                {
                    var linha = file.ReadLine();
                    var produto = linha.Split(';');
                    int productId = Convert.ToInt32(produto[0]);
                    if (productId > lastId)
                    {
                        lastId = productId;
                    }
                }
            }

            return lastId;
        }

        public static void insereNovoProduto(Produto Produto)
        {
            using (var file = File.AppendText(ProdutoRepositorioFake.nomeArquivoCSV))
            {
                file.WriteLine($"{Produto.Id};{Produto.Nome};{Produto.Preco}");
            }
        }
    }
}

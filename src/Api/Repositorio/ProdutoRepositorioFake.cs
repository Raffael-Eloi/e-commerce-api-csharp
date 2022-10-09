using Api.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Api.Repositorio
{
    public class ProdutoRepositorioFake
    {
        public static readonly string nomeArquivoCSV = "Repositorio\\produtos.csv";

        private static readonly List<Produto> _produtos = new List<Produto>
        {
            new Produto ( 1, "PS5", 50 ),
            new Produto ( 2, "TV do Edi 32 polegadas (Modelo 2002)", 30 ),
            new Produto ( 3, "Sanfona do Buxin", 10 ),
            new Produto ( 4, "Headset", 40 ),
            new Produto ( 5, "Livro", 15 )
        };

        public ProdutoRepositorioFake()
        {
            InsereLivrosEmArquivoCSV(_produtos);
        }

        private bool ProdutoEstaInserido(Produto Produto)
        {
            using (var file = File.OpenRead(nomeArquivoCSV))
            {
                Console.WriteLine(file);
            }
            // Console.WriteLine(_produtos);
            // Console.WriteLine(Produto);
            return true;
            // return _produtos.Contains(Produto);
        }

        private void InsereLivrosEmArquivoCSV(List<Produto> Produtos)
        {
            foreach (Produto Produto in Produtos)
            {
                using (var file = File.AppendText(nomeArquivoCSV))
                {
                    file.WriteLine($"{Produto.Id};{Produto.Nome};{Produto.Preco}");
                }
            }
            testes();
        }

        private void testes()
        {
            using (var file = File.OpenText(nomeArquivoCSV))
            {
                while (!file.EndOfStream)
                {
                    var linha = file.ReadLine();
                    var produto = linha.Split(';');
                    // Console.WriteLine($"{Convert.ToString(produto[0])} - {Convert.ToString(produto[1])} - {Convert.ToString(produto[2])}");
                }
            }
        }
    }
}

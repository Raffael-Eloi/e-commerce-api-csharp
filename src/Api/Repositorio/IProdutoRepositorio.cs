using Api.Model;
using System.Collections.Generic;

namespace Api.Repositorio
{
    interface IProdutoRepositorio
    {
        IEnumerable<Produto> Todos { get; }
        void Incluir(Produto Produto);
    }
}

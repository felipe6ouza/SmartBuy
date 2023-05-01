using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCompra.Domain.ProdutoAggregate
{
    public interface IProdutoRepository 
    {
        IEnumerable<Produto> ObterProdutos(IEnumerable<Guid> idList);
        Produto Obter(Guid id);
        void Registrar(Produto entity);
        void Atualizar(Produto entity);
        void Excluir(Produto entity);
    }
}

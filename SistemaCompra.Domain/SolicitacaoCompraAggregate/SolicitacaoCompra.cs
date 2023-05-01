using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; private set; }
        
        private const decimal VALOR_LIMITE_CONDICAO_PAGAMENTO = 50000m;

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Itens.Add(new Item(produto, qtde));
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            if (!itens.Any())
                 throw new BusinessRuleException("A solicitação de compra deve possuir itens!");

            if (CalcularTotalGeral(itens).Value > VALOR_LIMITE_CONDICAO_PAGAMENTO)
                CondicaoPagamento = new CondicaoPagamento(30);

            AddEvent(new CompraRegistradaEvent(Id, itens, TotalGeral.Value));
        }

        private Money CalcularTotalGeral(IEnumerable<Item> itens)
        {
            TotalGeral = new Money();

            foreach (var item in itens)
            {
                TotalGeral = TotalGeral.Add(new Money(item.Subtotal.Value));
            }

            return TotalGeral;
        }

    }
}

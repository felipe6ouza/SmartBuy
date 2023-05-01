using SistemaCompra.Domain.Core;
using System;
using System.Collections.Generic;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate.Events
{
    public class FalhaProcessamentoCompraEvent : Event
    {
        public Guid Id { get; }
        public string ErrorMessage { get; }

        public FalhaProcessamentoCompraEvent(Guid id, string errorMessage)
        {
            Id = id;
            ErrorMessage = errorMessage;
        }
    }
}

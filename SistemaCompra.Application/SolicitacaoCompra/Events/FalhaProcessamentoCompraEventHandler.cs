using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaCompra.Application.SolicitacaoCompra.Events
{
    public class FalhaProcessamentoCompraEventHandler : INotificationHandler<FalhaProcessamentoCompraEvent>
    {
        public Task Handle(FalhaProcessamentoCompraEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

    }
}

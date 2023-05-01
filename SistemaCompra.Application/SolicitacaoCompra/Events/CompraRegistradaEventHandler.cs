using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaCompra.Application.SolicitacaoCompra.Events
{
    public class CompraRegistradaEventHandler : INotificationHandler<CompraRegistradaEvent>
    {
        public Task Handle(CompraRegistradaEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

    }
}

using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.UoW;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly ISolicitacaoCompraRepository _solicitacaoCompraRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediator _mediator;

        public RegistrarCompraCommandHandler(IUnitOfWork uow, IMediator mediator, ISolicitacaoCompraRepository solicitacaoCompraRepository, IProdutoRepository produtoRepository) : base(uow, mediator)
        {
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
            _produtoRepository = produtoRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var compra = new SolicitacaoCompraAgg.SolicitacaoCompra(request.NomeFornecedor, request.UsuarioSolicitante);

            var idsProdutosSolicitacaoCompra = request.Itens.Select(c => c.Id).AsEnumerable();
            var produtos = _produtoRepository.ObterProdutos(idsProdutosSolicitacaoCompra);

            if (!produtos.Any() || !idsProdutosSolicitacaoCompra.All(id => produtos.Any(p => p.Id == id)))
            {
                var message = "Não foi possível encontrar um ou mais produtos associados à solicitação compra"; 
                
                await _mediator.Publish(new FalhaProcessamentoCompraEvent(compra.Id, message), cancellationToken);

                return await Task.FromResult(false);
            }

            foreach (var produto in produtos)
            {
                var quantidade = request.Itens.First(c => c.Id == produto.Id).Quantidade;
                compra.AdicionarItem(produto, quantidade);
            }

            compra.RegistrarCompra(compra.Itens);

            _solicitacaoCompraRepository.RegistrarCompra(compra);

            Commit();
            PublishEvents(compra.Events);

            return await Task.FromResult(true);
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaCompra.Application.Produto.Command.AtualizarPreco;
using SistemaCompra.Application.Produto.Command.RegistrarProduto;
using SistemaCompra.Application.Produto.Query.ObterProduto;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.ProdutoAggregate.Events;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using SistemaCompra.Infra.Data;
using SistemaCompra.Infra.Data.Produto;
using SistemaCompra.Infra.Data.SolicitacaoCompra;
using SistemaCompra.Infra.Data.UoW;
using System.Configuration;

namespace SistemaCompra.API.Setup
{
    public static class DependencyInjection 
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Repositories
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ISolicitacaoCompraRepository, SolicitacaoCompraRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Commands
            services.AddScoped<IRequestHandler<AtualizarPrecoCommand, bool>, AtualizarPrecoCommandHandler>();
            services.AddScoped<IRequestHandler<RegistrarCompraCommand, bool>, RegistrarCompraCommandHandler>();
            services.AddScoped<IRequestHandler<RegistrarProdutoCommand, bool>, RegistrarProdutoCommandHandler>();

            //Events
            services.AddScoped<INotificationHandler<PrecoAtualizadoEvent>, PrecoAtualizadoEventHandler>();
            services.AddScoped<INotificationHandler<CompraRegistradaEvent>, CompraRegistradaEventHandler>();

            //Querys
            services.AddScoped<IRequestHandler<ObterProdutoQuery, ObterProdutoViewModel>, ObterProdutoQueryHandler>();

            //Context
            services.AddDbContext<SistemaCompraContext>(options =>
              options.UseSqlServer(
                  configuration.GetConnectionString("DefaultConnection"),
                  o => o.MigrationsAssembly("SistemaCompra.API")));

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Reflection.Emit;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<SolicitacaoCompraAgg.SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoCompraAgg.SolicitacaoCompra> builder)
        {
            builder.ToTable("Compras");
            builder.HasMany(c => c.Itens);
            builder.Property(c => c.TotalGeral).HasConversion(m => m.Value, v => new Money(v)).IsRequired(); 
            builder.OwnsOne(c => c.NomeFornecedor);
            builder.OwnsOne(c => c.UsuarioSolicitante);
            builder.Property(c => c.CondicaoPagamento).HasConversion(c => c.ToString(), c => (CondicaoPagamento)Enum.Parse(typeof(CondicaoPagamento), c));
        }
    }


    public class ItemCompraConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(i =>  i.Id);
            builder.Property(i => i.Qtde).IsRequired();
        }
    }
}

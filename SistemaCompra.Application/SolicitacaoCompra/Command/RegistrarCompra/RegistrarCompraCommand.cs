using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        [MinLength(10, ErrorMessage = "O nome do usuário solicitante deve ter pelo menos 10 caracteres.")]
        public string UsuarioSolicitante { get; set; }

        [MinLength(10, ErrorMessage = "O nome do usuário fornecedor deve ter pelo menos 10 caracteres.")]
        public string NomeFornecedor { get; }

        [MinLength(1, ErrorMessage = "A lista de itens do pedido deve ter pelo menos um item.")]
        public List<ProdutoCompraViewModel> Itens { get; private set; }

        public RegistrarCompraCommand(string usuarioSolicitante, string nomeFornecedor, List<ProdutoCompraViewModel> itens)
        {
            UsuarioSolicitante = usuarioSolicitante;
            NomeFornecedor = nomeFornecedor;
            Itens = new List<ProdutoCompraViewModel>();
            Itens.AddRange(itens);
        }

    }

    public class ProdutoCompraViewModel
    {
        public Guid Id { get; set; }

        [Range(1, 99, ErrorMessage = "A quantidade de itens deve estar entre 1 e 99 itens.")]
        public int Quantidade { get; set; }

        public ProdutoCompraViewModel(Guid id, int quantidade)
        {
            Id = id;
            Quantidade = quantidade;
        }
    }


}

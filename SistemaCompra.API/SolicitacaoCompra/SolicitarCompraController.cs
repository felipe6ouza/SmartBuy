using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;

namespace SistemaCompra.API.SolicitacaoCompra
{
    public class SolicitarCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SolicitarCompraController(IMediator mediator) => _mediator = mediator;

        [HttpPost, Route("compra/solicitar")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult SolicitarCompra([FromBody] RegistrarCompraCommand registrarCompraCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ValidationProblemDetails(ModelState));
            }

            _mediator.Send(registrarCompraCommand);
            return Accepted();
        }

    }
}

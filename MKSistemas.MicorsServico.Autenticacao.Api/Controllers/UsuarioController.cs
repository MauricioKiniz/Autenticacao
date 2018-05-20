using MediatR;
using Microsoft.AspNetCore.Mvc;
using MKSistemas.MicrosServico.Autenticacao.Api.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKSistemas.MicrosServico.Autenticacao.Api.Controllers
{
    [Route("api/Usuario")]
    public class UsuarioController: Controller
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("LogarUsuario")]
        public IActionResult GetLogarUsuario(LogarUsuarioRequest request)
        {
            bool value = _mediator.Send(request).Result;
            return new JsonResult(value);
        }
    }
}

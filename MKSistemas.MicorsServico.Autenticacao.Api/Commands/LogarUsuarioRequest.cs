using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKSistemas.MicrosServico.Autenticacao.Api.Commands
{
    public class LogarUsuarioRequest: IRequest<bool>
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}

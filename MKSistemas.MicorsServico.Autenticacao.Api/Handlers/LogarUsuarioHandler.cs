using MediatR;
using MKSistemas.MicrosServico.Autenticacao.Api.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MKSistemas.MicrosServico.Autenticacao.Api.Handlers
{
    public class LogarUsuarioHandler: IRequestHandler<LogarUsuarioRequest, bool>
    {

        public Task<bool> Handle(LogarUsuarioRequest request, CancellationToken cancellationToken)
        {
            return new Task<bool>(() => true);
        }
    }
}

using MediatR;
using MKSistemas.MicrosServico.Autenticacao.Api.Commands;
using MKSistemas.MicrosServico.Autenticacao.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MKSistemas.MicrosServico.Autenticacao.Api.Handlers
{
    public class LogarUsuarioHandler: IRequestHandler<LogarUsuarioRequest, bool>
    {
        private readonly IDataCache _cache;

        public LogarUsuarioHandler(IDataCache cache)
        {
            _cache = cache;
        }

        public Task<bool> Handle(LogarUsuarioRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult<bool>(true);
        }
    }
}

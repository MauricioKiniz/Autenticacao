using System;
using System.Collections.Generic;
using System.Text;

namespace MKSistemas.MicrosServico.Autenticacao.Servicos
{
    public interface IDataCache
    {
        T Get<T>(string key);
        void Put<T>(string key, T data);
        void Remove(string key);
    }
}

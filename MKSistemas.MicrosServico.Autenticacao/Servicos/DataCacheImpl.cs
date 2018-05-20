using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKSistemas.MicrosServico.Autenticacao.Servicos
{
    public class DataCacheImpl : IDataCache
    {
        private static readonly string Separator = ":";
        private readonly IDistributedCache _distributedCache;
        private readonly string _name;

        public DataCacheImpl(string name, IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
            _name = name;
        }

        public T Get<T>(string key)
        {
            var data = _distributedCache.GetString($"{_name}{Separator}{key}");
            if (data == null)
                return default(T);
            return JsonConvert.DeserializeObject<T>(data);
        }

        public void Put<T>(string key, T data)
        {
            string serialized = JsonConvert.SerializeObject(data);
            _distributedCache.SetString($"{_name}{Separator}{key}", serialized);
        }

        public void Remove(string key)
        {
            _distributedCache.Remove($"{_name}{Separator}{key}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MediatR;
using Swashbuckle.AspNetCore.Swagger;
using MKSistemas.MicrosServico.Autenticacao.Servicos;
using Microsoft.Extensions.Caching.Distributed;

namespace MKSistemas.MicrosServico.Autenticacao.Api
{
    public class Startup
    {

        private string _redisConnectionString;
        private string _redisInstanceName;
        private string _redisCacheName;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            GetConfiguration();
            services.AddMvc();
            services.AddMediatR(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Autenticacao", Version = "v1" });
            });
            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = _redisConnectionString;
                option.InstanceName = _redisInstanceName;
            });
            RegisterIOC(services);

        }

        private void RegisterIOC(IServiceCollection services)
        {
            services.AddScoped<IDataCache>(c =>
                new DataCacheImpl(_redisCacheName, c.GetService<IDistributedCache>())
            );
        }

        private void GetConfiguration()
        {
            var redisSection = Configuration.GetSection("Redis");
            _redisConnectionString = redisSection.GetValue<string>("ConnectionString");
            _redisInstanceName = redisSection.GetValue<string>("InstanceName");
            _redisCacheName = redisSection.GetValue<string>("Name");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Autenticacao V1");
            });

            app.UseMvc();
        }
    }
}

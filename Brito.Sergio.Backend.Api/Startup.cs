using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Brito.Sergio.Backend.Acl;
using Brito.Sergio.Backend.Api.Automapper;
using Brito.Sergio.Backend.Domain.Interfaces.Services;
using Brito.Sergio.Backend.Infra;
using Brito.Sergio.Backend.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace Brito.Sergio.Backend.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            ConfigurarAutoMapper(services);

            ConfigurarRedis(services);

            ConfigurarInjecaoDependencia(services);

            services.AddControllers()
                    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
        }

        private void ConfigurarRedis(IServiceCollection services)
        {
            services.AddDistributedRedisCache(options => {
                options.Configuration = Configuration.GetConnectionString("Redis");
            });
        }

        private void ConfigurarInjecaoDependencia(IServiceCollection services)
        {
            services.AddTransient<IInvestimentoService, InvestimentoService>();
            services.AddSingleton<IRedisCache, RedisCache>();
        }

        private void ConfigurarAutoMapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

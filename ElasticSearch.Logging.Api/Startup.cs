using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElasticSearch.Logging.Api.Core.Configuration;
using ElasticSearch.Logging.Api.Core.DbContext;
using ElasticSearch.Logging.Api.Core.Mapping;
using ElasticSearch.Logging.Api.Domain.Mapping;
using ElasticSearch.Logging.Api.Domain.Repositories;
using ElasticSearch.Logging.Api.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ElasticSearch.Logging.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(this.Configuration);

            services.AddSingleton<AppConfiguration>();
            services.AddSingleton<IDbContextFactory, ElasticDbContextFactory>();
            services.AddSingleton<ITransactionLogRepository, TransactionLogRepository>();
            services.AddSingleton<TransactionLogDomainService>();
            services.AddSingleton<IElasticMapping, TransactionLogMap>();

            var sp = services.BuildServiceProvider();
            var service = sp.GetService<IElasticMapping>();

            service.Map();
            //services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}

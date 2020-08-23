using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperSample.BLL.Managers;
using DapperSample.BLL.Managers.Interfaces;
using DapperSample.DAL.Helpers;
using DapperSample.DAL.Services;
using DapperSample.DAL.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DapperSample.API
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
            services.AddControllers();

            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IProductService, ProductService>();

            services.AddSingleton<IConfiguration>(Configuration);
            SqlHelper.ConnectionString = Configuration.GetConnectionString("ProductDB");
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

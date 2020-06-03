using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using webApi.Business;
using webApi.DataAccess;
using webApi.Models;
using webApi.Repository;

namespace webApi
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
            services.AddDbContext<DataBaseContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));
            services.AddControllers();
            services.AddScoped<IRepository<Customer>, CustomerRepo>();
            services.AddScoped<IRepository<Orders>, OrderRepo>();
            services.AddScoped<IRepository<Product>, ProductRepo>();
            services.AddScoped<IRepository<OrderDetail>, OrderDetailRepo>();
            services.AddScoped<CustomerBusiness>();
            services.AddScoped<ProductBusiness>();
            services.AddScoped<OrderBusiness>();
            services.AddScoped<OrderDetailBusiness>()
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

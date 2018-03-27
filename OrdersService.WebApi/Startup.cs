using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrdersService.DataAccess.Models;

namespace OrdersService.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            services.AddCors(options => options.AddPolicy("AllowAll",
                builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            services.AddMvc();

            services.AddDbContext<OrdersServiceContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("OrdersService")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseCors("AllowAll");
            app.UseMvc();
        }
    }
}
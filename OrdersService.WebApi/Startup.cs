using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrdersService.BusinessLogic.Contracts.Persistance;
using OrdersService.DataAccess;
using OrdersService.DataAccess.Models;
using OrdersService.WebApi.Managers;
using OrdersService.WebApi.Models;

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
            ConfigureInfrustructure(services);

            ConfigureDependencies(services);
        }

        private void ConfigureDependencies(IServiceCollection services)
        {
            services.AddDbContext<OrdersServiceContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("OrdersService")));

            services.AddScoped<IOrdersRepository, OrdersRepository>();

            services.AddScoped<IOrdersPresenter, OrdersPresenter>();
        }

        private static void ConfigureInfrustructure(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.CreateMap<OrderEntity, OrderReadModel>()
                    .ForMember(x => x.Id, o => o.MapFrom(x => x.DisplayId));
            });

            services.AddCors(options => options.AddPolicy("AllowAll",
                builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            services.AddMvc();
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
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrdersService.BusinessLogic;
using OrdersService.BusinessLogic.CommandHandlers;
using OrdersService.BusinessLogic.Commands;
using OrdersService.BusinessLogic.Contracts.Commands;
using OrdersService.BusinessLogic.Contracts.Persistance;
using OrdersService.DataAccess;
using OrdersService.DataAccess.Models;
using OrdersService.WebApi.Managers;
using OrdersService.WebApi.Models;
using Serilog;

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
            services.AddScoped<ICommandHandler<UpdateOrderCommand>, UpdateOrderCommandHandler>();
            services.AddScoped<ICommandHandler<AddOrderCommand>, AddOrderCommandHandler>();
            services.AddScoped<ICommandBuilder, CommandBuilder>();
            services.AddScoped<ICommandHandlerFactory, CommandHandlerFactory>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        }

        private static void ConfigureInfrustructure(IServiceCollection services)
        {
            services.AddSingleton(Log.Logger);

            services.AddAutoMapper(config =>
            {
                config.CreateMap<OrderEntity, OrderReadModel>()
                    .ForMember(x => x.Id, o => o.MapFrom(x => x.DisplayId));

                config.CreateMap<OrderInputModel, UpdateOrderCommand>()
                    .IgnoreAllPropertiesWithAnInaccessibleSetter();

                config.CreateMap<UpdateOrderCommand, OrderEntity>()
                    .ForMember(x => x.DisplayId, o => o.MapFrom(x => x.Id));

                config.CreateMap<OrderEntity, Orders>()
                    .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
            });

            services.AddCors(options => options.AddPolicy("AllowAll",
                builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandler();
            app.UseCors("AllowAll");
            app.UseMvc();
        }
    }
}
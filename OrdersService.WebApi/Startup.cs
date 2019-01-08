using System.Net.Http;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrdersService.BusinessLogic;
using OrdersService.BusinessLogic.CommandHandlers;
using OrdersService.BusinessLogic.Commands;
using OrdersService.BusinessLogic.Contracts.Commands;
using OrdersService.BusinessLogic.Contracts.DomainModels;
using OrdersService.BusinessLogic.Contracts.Persistence;
using OrdersService.DataAccess;
using OrdersService.DataAccess.Entities;
using OrdersService.WebApi.Managers;
using OrdersService.WebApi.Models;
using Serilog;

namespace OrdersService.WebApi
{
    public sealed class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureInfrastructure(services);
            ConfigureDependencies(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");
            app.UseMvc();
        }

        private void ConfigureDependencies(IServiceCollection services)
        {
            services.AddDbContext<OrdersServiceContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("OrdersService")));

            services.AddSingleton<HttpClient>();
            services.AddSingleton<IIssuesProvider, IssuesProvider>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IOrdersPresenter, OrdersPresenter>();
            services.AddScoped<ICommandHandler<UpdateOrderCommand>, UpdateOrderCommandHandler>();
            services.AddScoped<ICommandHandler<AddOrderCommand>, AddOrderCommandHandler>();
            services.AddScoped<ICommandBuilder, CommandBuilder>();
            services.AddScoped<ICommandHandlerFactory, CommandHandlerFactory>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        }

        private static void ConfigureInfrastructure(IServiceCollection services)
        {
            services.AddSingleton(Log.Logger);

            services.AddAutoMapper(ConfigureMapper);

            services.AddCors(options => options.AddPolicy("AllowAll",
                builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private static void ConfigureMapper(IMapperConfigurationExpression config)
        {
            config.CreateMap<OrderInputModel, UpdateOrderCommand>();
            config.CreateMap<AddOrderCommand, OrderEntity>().ForMember(x => x.OrderId, c => c.Ignore());

            RepositoryMapper.ConfigureMapper(config);
        }
    }
}

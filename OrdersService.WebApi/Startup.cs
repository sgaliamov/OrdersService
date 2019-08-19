using System;
using System.Linq;
using System.Net.Http;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
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

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/doc/swagger.json", "Order API"); });
            app.UseCors("AllowWebClient");
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

            services.AddAutoMapper(ConfigureMapper, AppDomain.CurrentDomain.GetAssemblies());

            services.AddCors(options => options.AddPolicy(
                                 "AllowWebClient",
                                 builder => builder.WithOrigins("http://localhost:4200")
                                     .AllowAnyHeader()
                                     .AllowAnyMethod()));

            void RemoveTextJson(MvcOptions options)
            {
                var jsonOutputFormatter = options.OutputFormatters.OfType<JsonOutputFormatter>().FirstOrDefault();
                if (jsonOutputFormatter?.SupportedMediaTypes.Contains("text/json") == true)
                {
                    jsonOutputFormatter.SupportedMediaTypes.Remove("text/json");
                }
            }

            services.AddMvc(options =>
                {
                    //options.ReturnHttpNotAcceptable = true;

                    RemoveTextJson(options);

                    options.Filters.Add(new ValidateModelAttribute());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("doc",
                                   new OpenApiInfo
                                   {
                                       Version = "v1",
                                       Title = "Order API"
                                   });
            });
        }

        private static void ConfigureMapper(IMapperConfigurationExpression config)
        {
            config.CreateMap<OrderInputModel, UpdateOrderCommand>();
            config.CreateMap<OrderInputModel, AddOrderCommand>();
            config.CreateMap<AddOrderCommand, OrderEntity>().ForMember(x => x.OrderId, c => c.Ignore());
            config.CreateMap<OrderEntity, OrderReadModel>();

            RepositoryMapper.ConfigureMapper(config);
        }
    }

    internal sealed class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.ModelState.IsValid)
            {
                return;
            }

            if (actionContext.ActionArguments.Count == actionContext.ActionDescriptor.Parameters.Count)
            {
                actionContext.Result = new UnprocessableEntityObjectResult(actionContext.ModelState);
            }
            else
            {
                actionContext.Result = new BadRequestObjectResult(actionContext.ModelState);
            }
        }
    }
}
using System;
using System.Linq;
using System.Net.Http;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OrdersService.WebApi
{
    public sealed class Startup
    {
        private const string ApiTitle = "Order API";

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

            app.UseHttpsRedirection()
               .UseSwagger()
               .UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/doc/swagger.json", ApiTitle); })
               .UseCors("AllowWebClient")
               .UseMvc();
        }

        private void ConfigureDependencies(IServiceCollection services)
        {
            services.AddSingleton(Log.Logger)
                    .AddDbContext<OrdersServiceContext>(
                        options => options.UseSqlServer(Configuration.GetConnectionString("OrdersService")))
                    .AddSingleton<HttpClient>()
                    .AddSingleton<IIssuesProvider, IssuesProvider>()
                    .AddScoped<IOrdersRepository, OrdersRepository>()
                    .AddScoped<IOrdersPresenter, OrdersPresenter>()
                    .AddScoped<ICommandHandler<UpdateOrderCommand>, UpdateOrderCommandHandler>()
                    .AddScoped<ICommandHandler<AddOrderCommand>, AddOrderCommandHandler>()
                    .AddScoped<ICommandBuilder, CommandBuilder>()
                    .AddScoped<ICommandHandlerFactory, CommandHandlerFactory>()
                    .AddScoped<ICommandDispatcher, CommandDispatcher>();
        }

        private static void ConfigureInfrastructure(IServiceCollection services)
        {
            void ConfigureSwagger(SwaggerGenOptions options)
            {
                options.SwaggerDoc("doc",
                                   new OpenApiInfo
                                   {
                                       Version = "v1",
                                       Title = ApiTitle
                                   });
            }

            void ConfigureCors(CorsOptions options)
            {
                options.AddPolicy(
                    "AllowWebClient",
                    builder => builder.WithOrigins("http://localhost:4200")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            }

            services.AddAutoMapper(ConfigureMapper, AppDomain.CurrentDomain.GetAssemblies())
                    .AddCors(ConfigureCors)
                    .AddSwaggerGen(ConfigureSwagger)
                    .AddMvc(ConfigureMvc)
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private static void ConfigureMvc(MvcOptions mvcOptions)
        {
            void ConfigureMediaTypes(MvcOptions options)
            {
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                options.Filters.Add(new ProducesAttribute("application/json", "application/xml"));
                options.Filters.Add(new ConsumesAttribute("application/json"));

                var jsonOutputFormatter = options.OutputFormatters.OfType<JsonOutputFormatter>().Single();
                if (jsonOutputFormatter.SupportedMediaTypes.Contains("text/json"))
                {
                    jsonOutputFormatter.SupportedMediaTypes.Remove("text/json");
                }

                options.ReturnHttpNotAcceptable = true;
                options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
            }

            void EnableModelStateValidation(MvcOptions options)
            {
                options.Filters.Add(new ValidateModelFilter());
                options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status422UnprocessableEntity));
            }

            ConfigureMediaTypes(mvcOptions);
            EnableModelStateValidation(mvcOptions);
        }

        private static void ConfigureMapper(IMapperConfigurationExpression config)
        {
            config.CreateMap<OrderInputModel, UpdateOrderCommand>();
            config.CreateMap<OrderInputModel, AddOrderCommand>();
            config.CreateMap<AddOrderCommand, OrderEntity>().ForMember(x => x.OrderId, c => c.Ignore());
            config.CreateMap<OrderEntity, OrderReadModel>();

            RepositoryMapper.ConfigureMapper(config);
        }

        private sealed class ValidateModelFilter : ActionFilterAttribute
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
}

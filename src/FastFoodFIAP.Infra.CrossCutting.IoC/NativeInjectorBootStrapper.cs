using FastFoodFIAP.Application.AutoMapper;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.Services;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Infra.Data.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using GenericPack.Mediator;
using FastFoodFIAP.Infra.CrossCutting.Bus;
using System.Reflection;
using FastFoodFIAP.Infra.Data.Context;
using FastFoodFIAP.Domain.Commands.PagamentoCommands;
using FastFoodFIAP.Domain.Interfaces.Services;
using FastFoodFIAP.Infra.MercadoPago;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using GenericPack.Messaging;
using System.Data;

namespace FastFoodFIAP.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // Setting DBContexts
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Connectionstring")));

            services.AddScoped<AppDbContext>();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddScoped<IDbConnection, Npgsql.NpgsqlConnection>();

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application            
            services.AddScoped<IPagamentoApp, PagamentoApp>();
            services.AddScoped<ISituacaoPagamentoApp, SituacaoPagamentoApp>();

            // Infra - Data           
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<ISituacaoPagamentoRepository, SituacaoPagamentoRepository>();

            // AutoMapper Settings
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(InputModelToDomainMappingProfile));

            // Domain - Commands
            services.AddScoped<IRequestHandler<PagamentoCreateCommand, CommandResult>, PagamentoCreateCommandHandler>();
            services.AddScoped<IRequestHandler<PagamentoUpdateCommand, CommandResult>, PagamentoUpdateCommandHandler>();

            //Infra - Services
            services.AddScoped<IGatewayPagamento, MercadoPagoService>();
            
            //Gateway de Pagamento
            services.AddHttpClient<IGatewayPagamento, MercadoPagoService>(
            client =>
            {
                // Set the base address of the named client.
                client.BaseAddress = new Uri("https://api.mercadopago.com/");
            });
        }
    }
}

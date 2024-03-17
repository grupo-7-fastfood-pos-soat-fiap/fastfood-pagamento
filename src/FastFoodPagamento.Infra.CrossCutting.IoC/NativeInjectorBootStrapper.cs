using System.Data;
using System.Reflection;
using FastFoodPagamento.Application.AutoMapper;
using FastFoodPagamento.Application.Interfaces;
using FastFoodPagamento.Application.Services;
using FastFoodPagamento.Domain.Commands.PagamentoCommands;
using FastFoodPagamento.Domain.Interfaces;
using FastFoodPagamento.Domain.Interfaces.Services;
using FastFoodPagamento.Domain.PagamentoEvent;
using FastFoodPagamento.Infra.CrossCutting.Bus;
using FastFoodPagamento.Infra.Data.Context;
using FastFoodPagamento.Infra.Data.Repository;
using FastFoodPagamento.Infra.MercadoPago;
using GenericPack.Mediator;
using GenericPack.Messaging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FastFoodPagamento.Infra.CrossCutting.IoC
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

            // Domain Events
            services.AddScoped<INotificationHandler<PagamentoCreateEvent>, PagamentoEventHandler>();
            
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

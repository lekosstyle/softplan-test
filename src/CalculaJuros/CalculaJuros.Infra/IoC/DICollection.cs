namespace CalculaJuros.Infra.IoC
{
    using CalculaJuros.Domain.Interfaces;
    using CalculaJuros.Domain.Interfaces.HttpClient;
    using CalculaJuros.Domain.Interfaces.Services;
    using CalculaJuros.Domain.Interfaces.Validation;
    using CalculaJuros.Domain.Services;
    using CalculaJuros.Domain.Validation;
    using CalculaJuros.Infra.HttpClient;
    using Microsoft.Extensions.DependencyInjection;
    public class DICollection
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ICalculaJurosService, CalculaJurosService>();
            services.AddScoped<IShowMeTheCodeService, ShowMeTheCodeService>();
            services.AddScoped<ICalculaJurosDTOValidation, CalculaJurosDTOValidation>();
            services.AddScoped<ITaxaJurosServiceClient, TaxaJurosServiceClient>();
            services.AddHttpClient();
        }
    }
}

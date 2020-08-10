namespace RetornoTaxa.Infra.IoC
{
    using Microsoft.Extensions.DependencyInjection;
    using RetornoTaxa.Domain.Interfaces;
    using RetornoTaxa.Domain.Services;

    public class DICollection
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ITaxaService, TaxaService>();
        }
    }
}

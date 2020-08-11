namespace CalculaJuros.Infra.HttpClient
{
    using CalculaJuros.Domain.Interfaces.HttpClient;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class TaxaJurosServiceClient : ITaxaJurosServiceClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        public TaxaJurosServiceClient(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        public async Task<decimal> ObterRetornoTaxaAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config.GetValue<string>("BaseUri"));
            var request = new HttpRequestMessage(HttpMethod.Get, "api/taxaJuros");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<decimal>(await response.Content.ReadAsStringAsync()); 
        }
    }
}

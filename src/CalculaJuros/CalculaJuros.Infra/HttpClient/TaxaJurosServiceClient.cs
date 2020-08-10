namespace CalculaJuros.Infra.HttpClient
{
    using CalculaJuros.Domain.Interfaces.HttpClient;
    using System;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class TaxaJurosServiceClient : ITaxaJurosServiceClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TaxaJurosServiceClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<decimal> ObterRetornoTaxaAsync()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://host.docker.internal:32775");
            var request = new HttpRequestMessage(HttpMethod.Get, "api/taxaJuros");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<decimal>(await response.Content.ReadAsStringAsync()); 
        }
    }
}

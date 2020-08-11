namespace CalculaJuros.Test.Integration.Controllers
{
    using CalculaJuros.Test.Integration.Helpers;
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    public class CalculaJurosControllerTest
    {
        [Theory]
        [InlineData(100, 5)]
        public async Task CalcularJurosHappyDay(decimal valorInicial, int meses)
        {   
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"api/calculajuros?valorinicial={valorInicial}&meses={meses}");
                response.EnsureSuccessStatusCode();

                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Content.Should().NotBeNull();
                var result = JsonConvert.DeserializeObject<decimal>(await response.Content.ReadAsStringAsync());
                result.Should().Be(105.10m);

            }
        }

        [Theory]
        [InlineData(100, 20)]
        public async Task CalcularJuros_BadRequest_MesesInvalido(decimal valorInicial, int meses)
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"api/calculajuros?valorinicial={valorInicial}&meses={meses}");

                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
                response.Content.Should().NotBeNull();
                response.Content.ReadAsStringAsync().Result.Should().Be("Número de meses deve estar dentro do range de 1 -  12. Input: 20");

            }
        }

        [Theory]
        [InlineData(-100, 5)]
        public async Task CalcularJuros_BadRequest_ValorMenorQueZero(decimal valorInicial, int meses)
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"api/calculajuros?valorinicial={valorInicial}&meses={meses}");

                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
                response.Content.Should().NotBeNull();
                response.Content.ReadAsStringAsync().Result.Should().Be("O valor inicial deve ser maior que zero. Input: -100");

            }
        }
    }
}

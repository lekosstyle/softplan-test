namespace RetornoTaxa.Test.Integration.Controllers
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using RetornoTaxa.Test.Integration.Helpers;
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;


    public class TaxaJurosControllerTest
    {

        [Fact]
        public async Task ObterTaxaJuros()
        {
            using(var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("api/taxaJuros");
                response.EnsureSuccessStatusCode();

                response.StatusCode.Should().Be(HttpStatusCode.OK);
                var result = JsonConvert.DeserializeObject<decimal>(await response.Content.ReadAsStringAsync());
                result.Should().BeGreaterThan(0);
            }
        }
    } 
}

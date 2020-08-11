namespace CalculaJuros.Test.Integration.Controllers
{
    using CalculaJuros.Test.Integration.Helpers;
    using FluentAssertions;
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    public class ShowMeTheCodeControllerTest
    {
       [Fact]
       public async Task ObterUrl()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("api/showmethecode");
                response.EnsureSuccessStatusCode();

                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Content.ReadAsStringAsync().Result.Should().Be("https://github.com/lekosstyle/softplan-test");
                
            }
        }
    }
}

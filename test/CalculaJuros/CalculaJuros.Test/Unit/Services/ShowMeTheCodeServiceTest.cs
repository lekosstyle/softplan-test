namespace CalculaJuros.Test.Unit.Services
{
    using CalculaJuros.Domain.Interfaces.Services;
    using CalculaJuros.Domain.Services;
    using FluentAssertions;
    using System.Threading.Tasks;
    using Xunit;

    public class ShowMeTheCodeServiceTest
    {
        private readonly IShowMeTheCodeService _showMeTheCodeService;

        public ShowMeTheCodeServiceTest()
        {
            _showMeTheCodeService = new ShowMeTheCodeService();
        }

        [Fact]
        public async Task ObterUrlAsync()
        {
            var urlEsperada = "https://github.com/lekosstyle/softplan-test";
            var result = await _showMeTheCodeService.ObterUrlAsync();
            result.Should().Be(urlEsperada);
        }
    }
}

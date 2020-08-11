namespace RetornoTaxa.Test.Unit.Services
{
    using FluentAssertions;
    using RetornoTaxa.Domain.Interfaces;
    using RetornoTaxa.Domain.Services;
    using System.Threading.Tasks;
    using Xunit;

    public class TaxaServiceTest
    {
        private readonly ITaxaService _taxaService;

        public TaxaServiceTest()
        {
            _taxaService = new TaxaService();
        }

        [Fact]
        public async Task ObterRetornoTaxaAsync()
        {
            var jurosEsperado = 0.01m;
            var result = await _taxaService.ObterRetornoTaxaAsync();
            result.Should().Be(jurosEsperado);
        }
    }
}

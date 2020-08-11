using CalculaJuros.Domain.DTO;
using CalculaJuros.Domain.Interfaces.HttpClient;
using CalculaJuros.Domain.Interfaces.Services;
using CalculaJuros.Domain.Interfaces.Validation;
using CalculaJuros.Domain.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalculaJuros.Test.Unit.Services
{
    public class CalculaJurosServiceTest
    {
        private readonly ICalculaJurosService _calculaJurosService;
        private readonly Mock<ITaxaJurosServiceClient> _taxaJurosServiceClientMock = new Mock<ITaxaJurosServiceClient>();
        private readonly Mock<ICalculaJurosDTOValidation> _calculaJurosDTOValidationMock = new Mock<ICalculaJurosDTOValidation>();

        public CalculaJurosServiceTest()
        {
            _taxaJurosServiceClientMock.Setup(x => x.ObterRetornoTaxaAsync()).ReturnsAsync(0.01m);         
            _calculaJurosService = new CalculaJurosService(_taxaJurosServiceClientMock.Object, _calculaJurosDTOValidationMock.Object);
        }

        [Theory]
        [InlineData(100, 5, 105.10)]
        [InlineData(200, 5, 210.20)]
        [InlineData(550, 6, 583.84)]
        public async Task CalculaJurosAsync(decimal valorInicial, int meses, decimal valorEsperado)
        {
            var request = new  CalculaJurosDTO
            {
                valorInicial = valorInicial,
                meses = meses
            };

            _calculaJurosDTOValidationMock.Setup(x => x.isValid(It.IsAny<CalculaJurosDTO>())).Returns(string.Empty);

            var result = await _calculaJurosService.CalculaJurosAsync(request);
            result.Should().Be(valorEsperado);
        }
    }
}

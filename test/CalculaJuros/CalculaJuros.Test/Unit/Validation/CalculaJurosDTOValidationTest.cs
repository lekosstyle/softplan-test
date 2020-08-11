namespace RetornoTaxa.Test.Unit.Validation
{
    using CalculaJuros.Domain.DTO;
    using CalculaJuros.Domain.Interfaces.Validation;
    using CalculaJuros.Domain.Validation;
    using FluentAssertions;
    using Xunit;

    public class CalculaJurosDTOValidationTest
    {
        private readonly ICalculaJurosDTOValidation _calculaJurosDTOValidation; 
        public CalculaJurosDTOValidationTest()
        {
            _calculaJurosDTOValidation = new CalculaJurosDTOValidation();
        }

        [Theory]
        [InlineData(100, 5, "")]
        [InlineData(-100, 5, "O valor inicial deve ser maior que zero. Input: -100")]
        [InlineData(100, 15, "Número de meses deve estar dentro do range de 1 -  12. Input: 15")]
        public void IsValid(decimal valorInicial, int meses, string retorno)
        {
            var request = new CalculaJurosDTO
            {
                valorInicial = valorInicial, 
                meses = meses
            };
            var result = _calculaJurosDTOValidation.isValid(request);
            result.Should().Be(retorno);
        }
    }
}

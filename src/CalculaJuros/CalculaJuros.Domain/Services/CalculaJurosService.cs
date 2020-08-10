namespace CalculaJuros.Domain.Services
{
    using CalculaJuros.Domain.DTO;
    using CalculaJuros.Domain.Exception;
    using CalculaJuros.Domain.Interfaces.HttpClient;
    using CalculaJuros.Domain.Interfaces.Services;
    using CalculaJuros.Domain.Interfaces.Validation;
    using System;
    using System.Threading.Tasks;

    public class CalculaJurosService : ICalculaJurosService
    {
        private readonly ITaxaJurosServiceClient _taxaJurosServiceClient;
        private readonly ICalculaJurosDTOValidation _calculaJurosDTOValidation;

        public CalculaJurosService(ITaxaJurosServiceClient taxaJurosServiceClient, ICalculaJurosDTOValidation calculaJurosDTOValidation)
        {
            _taxaJurosServiceClient = taxaJurosServiceClient;
            _calculaJurosDTOValidation = calculaJurosDTOValidation;
        }
        
        public async Task<decimal> CalculaJurosAsync(CalculaJurosDTO dto)
        {
            var erro = _calculaJurosDTOValidation.isValid(dto);

            if (!string.IsNullOrEmpty(erro))
                throw new BusinessException(erro);            

            var taxa =  await _taxaJurosServiceClient.ObterRetornoTaxaAsync();

            var calculo = (decimal)Math.Pow((double)(1 + taxa), dto.meses);
            var valorTruncado = (dto.valorInicial * calculo).ToString("N2");

            return Convert.ToDecimal(valorTruncado);
        }
    }
}

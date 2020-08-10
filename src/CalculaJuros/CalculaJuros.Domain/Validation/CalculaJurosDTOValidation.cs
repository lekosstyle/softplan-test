
namespace CalculaJuros.Domain.Validation
{
    using CalculaJuros.Domain.DTO;
    using CalculaJuros.Domain.Interfaces.Validation;

    public class CalculaJurosDTOValidation : ICalculaJurosDTOValidation
    {

        public string isValid(CalculaJurosDTO dto)
        {
            if (dto.valorInicial <= 0)
                return $"O valor inicial deve ser maior que zero. Input: {dto.valorInicial}";

            if (dto.meses < 1 || dto.meses > 12)
                return $"Número de meses deve estar dentro do range de 1 -  12. Input: {dto.meses}";

            return string.Empty;
        }
    }
}

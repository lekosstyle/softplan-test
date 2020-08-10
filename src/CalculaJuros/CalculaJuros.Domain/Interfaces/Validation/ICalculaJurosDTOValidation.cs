
namespace CalculaJuros.Domain.Interfaces.Validation
{
    using CalculaJuros.Domain.DTO;
    public interface ICalculaJurosDTOValidation
    {
        string isValid(CalculaJurosDTO dto);
    }
}

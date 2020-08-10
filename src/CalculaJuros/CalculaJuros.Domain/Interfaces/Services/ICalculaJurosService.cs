namespace CalculaJuros.Domain.Interfaces.Services
{
    using CalculaJuros.Domain.DTO;
    using System.Threading.Tasks;

    public interface ICalculaJurosService
    {
        Task<decimal> CalculaJurosAsync(CalculaJurosDTO dto);
    }
}

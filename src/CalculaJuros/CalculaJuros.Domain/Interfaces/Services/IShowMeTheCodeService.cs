namespace CalculaJuros.Domain.Interfaces.Services
{
    using System.Threading.Tasks;

    public interface IShowMeTheCodeService
    {
        Task<string> ObterUrlAsync();
    }
}

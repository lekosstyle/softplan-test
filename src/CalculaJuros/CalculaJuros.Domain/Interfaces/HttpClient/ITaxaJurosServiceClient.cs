namespace CalculaJuros.Domain.Interfaces.HttpClient
{
    using System.Threading.Tasks;

    public interface ITaxaJurosServiceClient
    {
        Task<decimal> ObterRetornoTaxaAsync();
    }
}

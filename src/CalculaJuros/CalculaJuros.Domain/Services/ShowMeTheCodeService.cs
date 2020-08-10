namespace CalculaJuros.Domain.Services
{
    using CalculaJuros.Domain.Interfaces.Services;
    using System.Threading.Tasks;
    public class ShowMeTheCodeService : IShowMeTheCodeService
    {
        private const string URL = "https://github.com/lekosstyle/softplan-test";

        public async Task<string> ObterUrlAsync()
        {
            return await Task.FromResult(URL);
        }
    }
}

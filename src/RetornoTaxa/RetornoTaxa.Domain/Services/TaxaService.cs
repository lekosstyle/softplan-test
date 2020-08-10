using RetornoTaxa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetornoTaxa.Domain.Services
{
    public class TaxaService : ITaxaService
    {
        private const decimal TAXA = 0.01m;

        public async Task<decimal> ObterRetornoTaxaAsync()
        {
            return await Task.FromResult(TAXA);
        }
    }
}

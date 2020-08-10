using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetornoTaxa.Domain.Interfaces
{
    public interface ITaxaService
    {
        Task<decimal> ObterRetornoTaxaAsync();
    }
}

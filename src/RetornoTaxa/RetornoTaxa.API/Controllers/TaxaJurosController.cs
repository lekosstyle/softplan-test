namespace RetornoTaxa.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using RetornoTaxa.Domain.Interfaces;

    [ApiController]
    [Route("api/")]
    public class TaxaJurosController : ControllerBase
    {

        private readonly ILogger<TaxaJurosController> _logger;
        private readonly ITaxaService _taxaService;

        public TaxaJurosController(ILogger<TaxaJurosController> logger, ITaxaService taxaService)
        {
            _logger = logger;
            _taxaService = taxaService;
        }

        [HttpGet]
        [Route("taxaJuros")]
        public async Task<IActionResult> ObterTaxaJuros()
        {
            return Ok(await _taxaService.ObterRetornoTaxaAsync());
        }
        
    }
}

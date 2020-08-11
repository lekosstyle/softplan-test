namespace CalculaJuros.API.Controllers
{
    using System.Threading.Tasks;
    using CalculaJuros.Domain.DTO;
    using CalculaJuros.Domain.Exception;
    using CalculaJuros.Domain.Interfaces.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/")]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculaJurosService _calculaJurosService;

        public CalculaJurosController(ICalculaJurosService calculaJurosService)
        {
            _calculaJurosService = calculaJurosService;
        }

        [HttpGet("calculajuros")]
        public async Task<IActionResult> CalcularJuros([FromQuery] decimal valorInicial, [FromQuery] int meses)
        {
            try
            {
                var request = new CalculaJurosDTO
                {
                    meses = meses,
                    valorInicial = valorInicial

                };
                return Ok(await _calculaJurosService.CalculaJurosAsync(request));
            }
            catch(BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

    }
}

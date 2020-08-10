namespace CalculaJuros.API.Controllers
{
    using System.Threading.Tasks;
    using CalculaJuros.Domain.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly IShowMeTheCodeService _showMeTheCodeService;
        public ShowMeTheCodeController(IShowMeTheCodeService showMeTheCodeService)
        {
            _showMeTheCodeService = showMeTheCodeService;
        }

        [HttpGet]
        [Route("showmethecode")]
        public async Task<IActionResult> ObterUrlAsync()
        {
            return Ok(await _showMeTheCodeService.ObterUrlAsync());
        }
    }
}

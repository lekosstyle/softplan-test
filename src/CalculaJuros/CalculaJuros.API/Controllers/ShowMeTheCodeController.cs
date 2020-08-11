namespace CalculaJuros.API.Controllers
{
    using System.Threading.Tasks;
    using CalculaJuros.Domain.Interfaces.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly IShowMeTheCodeService _showMeTheCodeService;
        public ShowMeTheCodeController(IShowMeTheCodeService showMeTheCodeService)
        {
            _showMeTheCodeService = showMeTheCodeService;
        }

        [HttpGet("showmethecode")]
        public async Task<IActionResult> ObterUrl()
        {
            return Ok(await _showMeTheCodeService.ObterUrlAsync());
        }
    }
}

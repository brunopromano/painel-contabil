using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PainelContabil.API.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class LancamentoFinanceiroController : ControllerBase
    {
        private readonly ILogger<LancamentoFinanceiroController> _logger;

        public LancamentoFinanceiroController(ILogger<LancamentoFinanceiroController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public void Get()
        {
            
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PainelContabil.Domain;
using PainelContabil.Repository;

namespace PainelContabil.API.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class LancamentoFinanceiroController : ControllerBase
    {
        private readonly ILogger<LancamentoFinanceiroController> _logger;
        private readonly IPainelContabilRepository _repo;

        public LancamentoFinanceiroController(ILogger<LancamentoFinanceiroController> logger, IPainelContabilRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllLancamentoFinanceiro();

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(LancamentoFinanceiro model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/lancamentofinanceiro/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados");
            }

            return BadRequest();
        }
    }
}
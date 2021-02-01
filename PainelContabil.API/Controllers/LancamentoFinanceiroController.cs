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

        [HttpGet("{lancamentoId}")]
        public async Task<IActionResult> GetById(int lancamentoId)
        {
            try
            {
                var result = await _repo.GetLancamentoFinanceiroById(lancamentoId);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados!");
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

        [HttpPut("{lancamentoId}")]
        public async Task<IActionResult> Put(int lancamentoId, LancamentoFinanceiro model)
        {
            try
            {
                var lancamento = await _repo.GetLancamentoFinanceiroById(lancamentoId);

                if (lancamento == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/lancamentofinanceiro/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados!");
            }

            return BadRequest();
        }

        [HttpDelete("{lancamentoId}")]
        public async Task<IActionResult> Delete(int lancamentoId)
        {
            try
            {
                var result = await _repo.GetLancamentoFinanceiroById(lancamentoId);

                if (result == null) return NotFound();

                _repo.Delete(result);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados!");
            }

            return BadRequest();
        }
    }
}
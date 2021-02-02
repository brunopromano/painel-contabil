using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PainelContabil.Domain;
using PainelContabil.Repository;

namespace PainelContabil.API.Controllers
{
    /// <summary>
    /// Endpoint api/LancamentoFinanceiro
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
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

        /// <summary>
        /// Obtém uma lista de todos os lançamentos financeiros
        /// </summary>
        /// 
        /// <return></return>
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

        /// <summary>
        /// Obtém um lançamento financeiro específico pelo Id
        /// </summary>
        /// <param name="lancamentoId"></param>
        /// <return></return>
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

        /// <summary>
        /// Cria um lançamento financeiro
        /// </summary>
        /// <param name="model"></param>
        /// <return>O lançamento com </return>
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

        /// <summary>
        /// Edita um lançamento financeiro pelo Id
        /// </summary>
        /// <param name="lancamentoId"></param>
        /// <param name="model"></param>
        /// <return>O lançamento com as alterações feitas</return>
        [HttpPut("{lancamentoId}")]
        public async Task<IActionResult> Put(int lancamentoId, LancamentoFinanceiro model)
        {
            try
            {
                
                var lancamento = await _repo.GetLancamentoFinanceiroById(lancamentoId);

                if (lancamento == null) return NotFound();

                if (lancamento.Status == "Conciliado") {
                    return BadRequest(new { id = lancamento.Id, erro = $"O lançamento #{lancamento.Id} já está conciliado e não pode ser deletado!"});
                }

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

        /// <summary>
        /// Deleta um lançamento financeiro pelo Id
        /// </summary>
        /// <param name="lancamentoId"></param>
        [HttpDelete("{lancamentoId}")]
        public async Task<IActionResult> Delete(int lancamentoId)
        {
            try
            {
                var lancamento = await _repo.GetLancamentoFinanceiroById(lancamentoId);

                if (lancamento == null) return NotFound();

                if (lancamento.Status == "Conciliado") {
                    return BadRequest(new { id = lancamento.Id, erro = $"O lançamento #{lancamento.Id} já está conciliado e não pode ser deletado!"});
                }

                _repo.Delete(lancamento);

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
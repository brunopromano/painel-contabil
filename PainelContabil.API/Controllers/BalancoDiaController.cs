using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PainelContabil.Repository;

namespace PainelContabil.API.Controllers
{
    /// <summary>
    /// Endpoint BalancoDia
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BalancoDiaController : ControllerBase
    {
        private readonly ILogger<BalancoDiaController> _logger;
        private readonly IBalancoDiaRepository _repo;

        public BalancoDiaController(ILogger<BalancoDiaController> logger, IBalancoDiaRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        /// <summary>
        /// Obtém o relatório mensal agrupado por dia
        /// </summary>
        /// <param name="mes">Mês a ser consultado</param>
        /// <param name="ano">Ano a ser consultado</param>
        /// <return>Lista com o resultado o mês/ano</return>
        [HttpGet("{mes}/{ano}")]
        public IActionResult Get(int mes, int ano)
        {
            try
            {
                var results = _repo.GetRelatorioMensal(mes, ano);

                if (results == null) return NotFound();

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados");
            }
        }
    }
}
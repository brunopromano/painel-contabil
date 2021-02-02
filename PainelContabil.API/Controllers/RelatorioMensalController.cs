using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PainelContabil.Repository;

namespace PainelContabil.API.Controllers
{
    /// <summary>
    /// Endpoint RelatorioMensal
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioMensalController : ControllerBase
    {
        private readonly ILogger<RelatorioMensalController> _logger;
        private readonly IRelatorioMensalRepository _repo;

        public RelatorioMensalController(ILogger<RelatorioMensalController> logger, IRelatorioMensalRepository repo)
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
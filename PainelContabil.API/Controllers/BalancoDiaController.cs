using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PainelContabil.Repository;

namespace PainelContabil.API.Controllers
{
    [Route("api/{controller}")]
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
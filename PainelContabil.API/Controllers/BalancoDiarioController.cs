using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PainelContabil.Repository;

namespace PainelContabil.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BalancoDiarioController : ControllerBase
    {
        private readonly ILogger<IBalancoDiarioRepository> _logger;
        private readonly IBalancoDiarioRepository _repo;

        public BalancoDiarioController(ILogger<IBalancoDiarioRepository> logger, IBalancoDiarioRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }
        
        /// <summary>
        /// Obtém o balanço diário
        /// </summary>
        /// <param name="dia">Dia a ser consultado</param>
        /// <return>Lista com o balanço do dia</return>
        [HttpGet("{dia}")]
        public IActionResult Get(DateTime dia)
        {
            try
            {
                var result = _repo.GetBalancoDiario(dia);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco de Dados");
            }
        }
    }
}
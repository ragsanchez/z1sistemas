using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TesteLab.Models;
using TesteLab.Repository;
using TesteLab.Services;

namespace TesteLab.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("[controller]")]
    [ApiController]    
    public class PedidoController : ControllerBase
    {
        PedidoRepository repos;
        PedidoService service;

        private readonly ILogger<PedidoController> _logger;

        public PedidoController(ILogger<PedidoController> logger)
        {
            _logger = logger;
            repos = new PedidoRepository();

            service = new PedidoService();
        }

        [HttpGet("importacoes/{id}")]
        public IActionResult Obter(int id)
        {
            var result = repos.Obter(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("importacoes")]
        public IActionResult ObterTodos()
        {
            var result = repos.ObterTodos();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("insert")]
        public IActionResult insert([FromBody] ICollection<ItemPedidoDTO> pedidodto)        
        {
            var result = service.Insert(pedidodto, getUserFromAuthentication());

            if (result.Any())
            {
                return BadRequest(result);
            }
            return Ok(result); 
        }

        private string getUserFromAuthentication()
        {
            return "Usuário 1";
        }
    }
}

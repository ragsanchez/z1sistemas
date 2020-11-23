using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using TesteCliente.Dominio;
using TesteCliente.Services;

namespace TesteCliente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        ClienteService service;

        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
            service = new ClienteService();
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var result = service.GetCliente(id);

                if (result.Result == null)
                {
                    return NotFound();
                }
                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                service.DeleteCliente(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                return StatusCode(500);
            }
        }

        [HttpPut]
        public IActionResult Update(Cliente cliente)
        {
            try
            {
                service.UpdateCliente(cliente);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Insert(Cliente cliente)
        {
            try
            {
                service.InsertCliente(cliente);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                return StatusCode(500);
            }
        }
    }
}

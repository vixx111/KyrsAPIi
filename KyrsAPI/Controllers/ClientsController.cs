using KyrsAPI.Models;
using KyrsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace KyrsAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ClientService clientService;

        public ClientsController(ClientService service)
        {
            this.clientService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
        {
            return Ok(await clientService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientById(int id)
        {
            var client = await clientService.GetById(id);
            if (client == null) return NotFound();
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient([FromBody] Client client)
        {
            await clientService.Create(client);
            return CreatedAtAction(nameof(GetClientById), new { id = client.ClientId }, client);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Client>> UpdateClient(int id, [FromBody] Client client)
        {
            if (client.ClientId != id) return BadRequest();
            await clientService.Update(client);
            return Ok(client);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await clientService.Delete(id);
            return NoContent();
        }
    }
}


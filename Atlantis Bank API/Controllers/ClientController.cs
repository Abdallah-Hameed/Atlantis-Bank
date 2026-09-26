using Atlantis_Bank_API.DTOs;
using Atlantis_Bank_API.DTOs.Client;
using Atlantis_Bank_API.Mappers;
using Atlantis_Bank_BLL;
using AtlantisBank.BLL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Atlantis_Bank_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<clsClientDto>>> GetAllClients()
        {
            DataTable dt = await clsClient.GetAllClientsAsync();

            IEnumerable<clsClientDto> clients = clsClientMapper.Map(dt);

            return Ok(clients);
        }

        [HttpGet("{id}")]
        public ActionResult<clsClientDto> GetClientById(int id)
        {
            clsClient client = clsClient.Find(id);

            if (client == null)
                return NotFound();

            clsClientDto dto = clsClientMapper.Map(client);

            return Ok(dto);
        }

        [HttpPost("Add")]
        public IActionResult AddClient(clsAddClientDto dto)
        {
            clsClient client = new clsClient();

            clsClientMapper.MapToClient(dto, client);

            enOperationResult result = client.Save();

            if (result == enOperationResult.NoPermission)
                return StatusCode(403);

            if (result == enOperationResult.NationalNoExists)
                return Conflict("Email already exists");

            if (result == enOperationResult.EmailExists)
                return Conflict("Email already exists");

            if (result == enOperationResult.Failed)
                return BadRequest();

            if (result != enOperationResult.Success)
                return BadRequest();

            return Ok(client.ClientID);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, clsAddClientDto dto)
        {
            clsClient client = clsClient.Find(id);

            if (client == null)
                return NotFound();

            clsClientMapper.MapToClient(dto, client);

            enOperationResult result = client.Save();

            if (result == enOperationResult.NoPermission)
                return StatusCode(403);

            if (result == enOperationResult.NationalNoExists)
                return Conflict("Email already exists");

            if (result == enOperationResult.EmailExists)
                return Conflict("Email already exists");

            if (result == enOperationResult.Failed)
                return BadRequest();

            if (result != enOperationResult.Success)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            enOperationResult result = clsClient.DeleteClient(id);

            if (result == enOperationResult.NoPermission)
                return StatusCode(403);

            if (result == enOperationResult.NotFound)
                return NotFound();

            if (result == enOperationResult.Failed)
                return BadRequest();

            if (result != enOperationResult.Success)
                return BadRequest();

            return NoContent();
        }
    }
}
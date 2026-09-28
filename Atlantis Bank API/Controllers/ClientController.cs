using Atlantis_Bank_API.DTOs;
using Atlantis_Bank_API.DTOs.Client;
using Atlantis_Bank_API.Mappers;
using Atlantis_Bank_BLL;
using AtlantisBank.BLL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace Atlantis_Bank_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [Authorize(Policy = "Client_View")]
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<clsClientDto>>> GetAllClients()
        {
            DataTable dt = await clsClient.GetAllClientsAsync();

            IEnumerable<clsClientDto> clients = clsClientMapper.Map(dt);

            return Ok(clients);
        }

        [Authorize(Policy = "Client_View")]
        [HttpGet("{id}")]
        public ActionResult<clsClientDto> GetClientById(int id)
        {
            clsClient client = clsClient.Find(id);

            if (client == null)
                return NotFound();

            clsClientDto dto = clsClientMapper.Map(client);

            return Ok(dto);
        }

        [Authorize(Policy = "Client_Add")]
        [HttpPost("Add")]
        public IActionResult AddClient(clsAddClientDto dto)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var actorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "unknown";
            var actorName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "unknown";

            clsClient client = new clsClient();

            clsClientMapper.MapToClient(dto, client);

            enOperationResult result = client.Save();

            if (result == enOperationResult.NoPermission)
            {
                _logger.LogWarning(
                    "AddClient failed (no permission). Actor={ActorId}/{ActorName}, NationalNumber={NationalNumber}, IP={IP}",
                    actorId, actorName, dto.NationalNo, ip);

                return StatusCode(403, "You do not have permission to add clients.");
            }

            if (result == enOperationResult.NationalNumberExists)
            {
                _logger.LogWarning(
                    "AddClient failed (national number exists). Actor={ActorId}/{ActorName}, NationalNumber={NationalNumber}, IP={IP}",
                    actorId, actorName, dto.NationalNo, ip);

                return Conflict("National number already exists");
            }

            if (result == enOperationResult.EmailExists)
            {
                _logger.LogWarning(
                    "AddClient failed (email exists). Actor={ActorId}/{ActorName}, Email={Email}, IP={IP}",
                    actorId, actorName, dto.Email, ip);

                return Conflict("Email already exists");
            }

            if (result == enOperationResult.CountryNotFound)
                return NotFound("Country not found");

            if (result == enOperationResult.BranchNotFound)
                return NotFound("Branch not found");

            if (result == enOperationResult.Failed)
            {
                _logger.LogError(
                    "AddClient failed (unexpected error). Actor={ActorId}/{ActorName}, NationalNumber={NationalNumber}, IP={IP}",
                    actorId, actorName, dto.NationalNo, ip);

                return BadRequest();
            }

            if (result != enOperationResult.Success)
                return BadRequest();

            _logger.LogInformation(
                "AddClient succeeded. Actor={ActorId}/{ActorName}, NewClientID={ClientID}, NationalNumber={NationalNumber}, IP={IP}",
                actorId, actorName, client.ClientID, dto.NationalNo, ip);

            return Ok(client.ClientID);
        }

        [Authorize(Policy = "Client_Edit")]
        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, clsAddClientDto dto)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var actorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "unknown";
            var actorName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "unknown";

            clsClient client = clsClient.Find(id);

            if (client == null)
                return NotFound();

            clsClientMapper.MapToClient(dto, client);

            enOperationResult result = client.Save();

            if (result == enOperationResult.NoPermission)
            {
                _logger.LogWarning(
                    "UpdateClient failed (no permission). Actor={ActorId}/{ActorName}, TargetClientID={TargetClientID}, IP={IP}",
                    actorId, actorName, id, ip);

                return StatusCode(403, "You do not have permission to edit clients.");
            }

            if (result == enOperationResult.NationalNumberExists)
            {
                _logger.LogWarning(
                    "UpdateClient failed (national number exists). Actor={ActorId}/{ActorName}, TargetClientID={TargetClientID}, NationalNumber={NationalNumber}, IP={IP}",
                    actorId, actorName, id, dto.NationalNo, ip);

                return Conflict("National number already exists");
            }

            if (result == enOperationResult.EmailExists)
            {
                _logger.LogWarning(
                    "UpdateClient failed (email exists). Actor={ActorId}/{ActorName}, TargetClientID={TargetClientID}, Email={Email}, IP={IP}",
                    actorId, actorName, id, dto.Email, ip);

                return Conflict("Email already exists");
            }

            if (result == enOperationResult.CountryNotFound)
                return NotFound("Country not found");

            if (result == enOperationResult.BranchNotFound)
                return NotFound("Branch not found");

            if (result == enOperationResult.Failed)
            {
                _logger.LogError(
                    "UpdateClient failed (unexpected error). Actor={ActorId}/{ActorName}, TargetClientID={TargetClientID}, IP={IP}",
                    actorId, actorName, id, ip);

                return BadRequest();
            }

            if (result != enOperationResult.Success)
                return BadRequest();

            _logger.LogInformation(
                "UpdateClient succeeded. Actor={ActorId}/{ActorName}, TargetClientID={TargetClientID}, IP={IP}",
                actorId, actorName, id, ip);

            return Ok();
        }

        [Authorize(Policy = "Client_Delete")]
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var actorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "unknown";
            var actorName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "unknown";

            enOperationResult result = clsClient.DeleteClient(id);

            if (result == enOperationResult.NoPermission)
            {
                _logger.LogWarning(
                    "DeleteClient failed (no permission). Actor={ActorId}/{ActorName}, TargetClientID={TargetClientID}, IP={IP}",
                    actorId, actorName, id, ip);

                return StatusCode(403, "You do not have permission to delete clients.");
            }

            if (result == enOperationResult.NotFound)
                return NotFound();

            if (result == enOperationResult.Failed)
            {
                _logger.LogError(
                    "DeleteClient failed (unexpected error). Actor={ActorId}/{ActorName}, TargetClientID={TargetClientID}, IP={IP}",
                    actorId, actorName, id, ip);

                return BadRequest();
            }

            if (result != enOperationResult.Success)
                return BadRequest();

            _logger.LogWarning(
                "DeleteClient succeeded (sensitive operation). Actor={ActorId}/{ActorName}, TargetClientID={TargetClientID}, IP={IP}",
                actorId, actorName, id, ip);

            return NoContent();
        }
    }
}
using Atlantis_Bank_API.DTOs.Employee;
using Atlantis_Bank_API.Mappers;
using AtlantisBank.BLL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace Atlantis_Bank_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [Authorize(Policy = "Employee_View")]
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<clsEmployeeListDto>>> GetAllEmployees()
        {
            DataTable dt = await clsEmployee.GetAllEmployees();

            IEnumerable<clsEmployeeListDto> employees = clsEmployeeMapper.Map(dt);

            return Ok(employees);
        }

        [Authorize(Policy = "Employee_View")]
        [HttpGet("{id}")]
        public ActionResult<clsEmployeeDto> GetEmployeeById(int id)
        {
            clsEmployee employee = clsEmployee.Find(id);

            if (employee == null)
                return NotFound();

            clsEmployeeDto dto = clsEmployeeMapper.Map(employee);

            return Ok(dto);
        }

        [Authorize(Policy = "Employee_Add")]
        [HttpPost("Add")]
        public IActionResult AddEmployee(clsAddEmployeeDto dto)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var actorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "unknown";
            var actorName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "unknown";

            clsEmployee employee = new clsEmployee();

            clsEmployeeMapper.MapToEmployee(dto, employee);

            enOperationResult result = employee.Save();

            if (result == enOperationResult.NoPermission)
            {
                _logger.LogWarning(
                    "AddEmployee failed (no permission). Actor={ActorId}/{ActorName}, NationalNumber={NationalNumber}, IP={IP}",
                    actorId, actorName, dto.NationalNumber, ip);

                return StatusCode(403, "You do not have permission to add employees.");
            }

            if (result == enOperationResult.NationalNumberExists)
            {
                _logger.LogWarning(
                    "AddEmployee failed (national number exists). Actor={ActorId}/{ActorName}, NationalNumber={NationalNumber}, IP={IP}",
                    actorId, actorName, dto.NationalNumber, ip);

                return Conflict("National number already exists");
            }

            if (result == enOperationResult.EmailExists)
            {
                _logger.LogWarning(
                    "AddEmployee failed (email exists). Actor={ActorId}/{ActorName}, Email={Email}, IP={IP}",
                    actorId, actorName, dto.Email, ip);

                return Conflict("Email already exists");
            }

            if (result == enOperationResult.CountryNotFound)
                return NotFound("Country not found");

            if (result == enOperationResult.BranchNotFound)
                return NotFound("Branch not found");

            if (result == enOperationResult.PositionNotFound)
                return NotFound("Position not found");

            if (result == enOperationResult.Failed)
            {
                _logger.LogError(
                    "AddEmployee failed (unexpected error). Actor={ActorId}/{ActorName}, NationalNumber={NationalNumber}, IP={IP}",
                    actorId, actorName, dto.NationalNumber, ip);

                return BadRequest();
            }

            if (result != enOperationResult.Success)
                return BadRequest();

            _logger.LogInformation(
                "AddEmployee succeeded. Actor={ActorId}/{ActorName}, NewEmployeeID={EmployeeID}, NationalNumber={NationalNumber}, IP={IP}",
                actorId, actorName, employee.EmployeeID, dto.NationalNumber, ip);

            return Ok(employee.EmployeeID);
        }

        [Authorize(Policy = "Employee_Edit")]
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, clsAddEmployeeDto dto)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var actorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "unknown";
            var actorName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "unknown";

            clsEmployee employee = clsEmployee.Find(id);

            if (employee == null)
                return NotFound();

            clsEmployeeMapper.MapToEmployee(dto, employee);

            enOperationResult result = employee.Save();

            if (result == enOperationResult.NoPermission)
            {
                _logger.LogWarning(
                    "UpdateEmployee failed (no permission). Actor={ActorId}/{ActorName}, TargetEmployeeID={TargetEmployeeID}, IP={IP}",
                    actorId, actorName, id, ip);

                return StatusCode(403, "You do not have permission to edit employees.");
            }

            if (result == enOperationResult.NationalNumberExists)
            {
                _logger.LogWarning(
                    "UpdateEmployee failed (national number exists). Actor={ActorId}/{ActorName}, TargetEmployeeID={TargetEmployeeID}, NationalNumber={NationalNumber}, IP={IP}",
                    actorId, actorName, id, dto.NationalNumber, ip);

                return Conflict("National number already exists");
            }

            if (result == enOperationResult.EmailExists)
            {
                _logger.LogWarning(
                    "UpdateEmployee failed (email exists). Actor={ActorId}/{ActorName}, TargetEmployeeID={TargetEmployeeID}, Email={Email}, IP={IP}",
                    actorId, actorName, id, dto.Email, ip);

                return Conflict("Email already exists");
            }

            if (result == enOperationResult.CountryNotFound)
                return NotFound("Country not found");

            if (result == enOperationResult.BranchNotFound)
                return NotFound("Branch not found");

            if (result == enOperationResult.PositionNotFound)
                return NotFound("Position not found");

            if (result == enOperationResult.Failed)
            {
                _logger.LogError(
                    "UpdateEmployee failed (unexpected error). Actor={ActorId}/{ActorName}, TargetEmployeeID={TargetEmployeeID}, IP={IP}",
                    actorId, actorName, id, ip);

                return BadRequest();
            }

            if (result != enOperationResult.Success)
                return BadRequest();

            _logger.LogInformation(
                "UpdateEmployee succeeded. Actor={ActorId}/{ActorName}, TargetEmployeeID={TargetEmployeeID}, IP={IP}",
                actorId, actorName, id, ip);

            return Ok();
        }

        [Authorize(Policy = "Employee_Delete")]
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var actorId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "unknown";
            var actorName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value ?? "unknown";

            enOperationResult result = clsEmployee.DeleteEmployee(id);

            if (result == enOperationResult.NoPermission)
            {
                _logger.LogWarning(
                    "DeleteEmployee failed (no permission). Actor={ActorId}/{ActorName}, TargetEmployeeID={TargetEmployeeID}, IP={IP}",
                    actorId, actorName, id, ip);

                return StatusCode(403, "You do not have permission to delete employees.");
            }

            if (result == enOperationResult.NotFound)
                return NotFound("Employee is not found");

            if (result == enOperationResult.Failed)
            {
                _logger.LogError(
                    "DeleteEmployee failed (unexpected error). Actor={ActorId}/{ActorName}, TargetEmployeeID={TargetEmployeeID}, IP={IP}",
                    actorId, actorName, id, ip);

                return BadRequest();
            }

            if (result != enOperationResult.Success)
                return BadRequest();

            _logger.LogWarning(
                "DeleteEmployee succeeded (sensitive operation). Actor={ActorId}/{ActorName}, TargetEmployeeID={TargetEmployeeID}, IP={IP}",
                actorId, actorName, id, ip);

            return NoContent();
        }
    }
}
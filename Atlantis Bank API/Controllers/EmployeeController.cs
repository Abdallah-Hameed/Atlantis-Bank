using Atlantis_Bank_API.DTOs.Employee;
using Atlantis_Bank_API.Mappers;
using AtlantisBank.BLL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Atlantis_Bank_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<clsEmployeeDto>>> GetAllEmployees()
        {
            DataTable dt = await clsEmployee.GetAllEmployees();

            IEnumerable<clsEmployeeDto> employees = clsEmployeeMapper.Map(dt);

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<clsEmployeeDto> GetEmployeeById(int id)
        {
            clsEmployee employee = clsEmployee.Find(id);

            if (employee == null)
                return NotFound();

            clsEmployeeDto dto = clsEmployeeMapper.Map(employee);

            return Ok(dto);
        }

        [HttpPost("Add")]
        public IActionResult AddEmployee(clsAddEmployeeDto dto)
        {
            clsEmployee employee = new clsEmployee();

            clsEmployeeMapper.MapToEmployee(dto, employee);

            enOperationResult result = employee.Save();

            if (result == enOperationResult.NoPermission)
                return StatusCode(403, "You do not have permission to add employees.");

            if (result == enOperationResult.NationalNumberExists)
                return Conflict("National number already exists");

            if (result == enOperationResult.EmailExists)
                return Conflict("Email already exists");

            if (result == enOperationResult.CountryNotFound)
                return NotFound("Country not found");

            if (result == enOperationResult.BranchNotFound)
                return NotFound("Branch not found");

            if (result == enOperationResult.PositionNotFound)
                return NotFound("Position not found");

            if (result == enOperationResult.Failed)
                return BadRequest();

            if (result != enOperationResult.Success)
                return BadRequest();

            return Ok(employee.EmployeeID);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, clsAddEmployeeDto dto)
        {
            clsEmployee employee = clsEmployee.Find(id);

            if (employee == null)
                return NotFound();

            clsEmployeeMapper.MapToEmployee(dto, employee);

            enOperationResult result = employee.Save();

            if (result == enOperationResult.NoPermission)
                return StatusCode(403, "You do not have permission to edit employees.");

            if (result == enOperationResult.NationalNumberExists)
                return Conflict("National number already exists");

            if (result == enOperationResult.EmailExists)
                return Conflict("Email already exists");

            if (result == enOperationResult.CountryNotFound)
                return NotFound("Country not found");

            if (result == enOperationResult.BranchNotFound)
                return NotFound("Branch not found");

            if (result == enOperationResult.PositionNotFound)
                return NotFound("Position not found");

            if (result == enOperationResult.Failed)
                return BadRequest();

            if (result != enOperationResult.Success)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            enOperationResult result = clsEmployee.DeleteEmployee(id);

            if (result == enOperationResult.NoPermission)
                return StatusCode(403, "You do not have permission to delete employees.");

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
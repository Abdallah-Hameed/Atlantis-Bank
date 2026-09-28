using Atlantis_Bank_API.DTOs;
using Atlantis_Bank_API.Mappers;
using Atlantis_Bank_BLL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Atlantis_Bank_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<clsAccountTypeDTO> GetAccountTypeByID(int id)
        {
            clsAccountType accountType = clsAccountType.Find(id);

            if (accountType == null)
                return NotFound();

            clsAccountTypeDTO dto = clsAccountTypeMapper.ToDTO(accountType);

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAccountType(int id, clsAccountTypeDTO dto)
        {
            clsAccountType accountType = clsAccountType.Find(id);

            if (accountType == null)
                return NotFound();

            accountType.AccountTypeDescription = dto.AccountTypeDescription;

            if (!accountType.Save())
                return BadRequest();

            return Ok();
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<clsAccountTypeDTO>>> GetAllAccountTypes()
        {
            DataTable dt = await clsAccountType.GetAllAccountTypes();

            IEnumerable<clsAccountTypeDTO> accountTypes = clsAccountTypeMapper.ToDTOList(dt);

            return Ok(accountTypes);
        }
    }
}
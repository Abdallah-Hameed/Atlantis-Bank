using Atlantis_Bank_API.DTOs;
using Atlantis_Bank_API.Mappers;
using Atlantis_Bank_BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Atlantis_Bank_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        [HttpGet("All")]
        public async Task<ActionResult<List<clsRoleDTO>>> GetAllRoles()
        {
            var dt = await clsRole.GetAllRoles();

            return Ok(clsRoleMapper.ToDTOList(dt));
        }

        [HttpGet("{id}")]
        public ActionResult<clsRoleDTO> GetRoleByID(int id)
        {
            clsRole role = clsRole.Find(id);

            if (role == null)
                return NotFound();

            return Ok(clsRoleMapper.ToDTO(role));
        }
    }
}
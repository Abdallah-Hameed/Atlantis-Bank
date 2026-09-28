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
    public class PositionController : ControllerBase
    {
        [HttpGet("All")]
        public async Task<ActionResult<List<clsPositionDTO>>> GetAllPositions()
        {
            var dt = await clsPosition.GetAllPositions();

            return Ok(clsPositionMapper.ToDTOList(dt));
        }

        [HttpGet("{id}")]
        public ActionResult<clsPositionDTO> GetPositionByID(int id)
        {
            clsPosition position = clsPosition.Find(id);

            if (position == null)
                return NotFound();

            return Ok(clsPositionMapper.ToDTO(position));
        }
    }
}
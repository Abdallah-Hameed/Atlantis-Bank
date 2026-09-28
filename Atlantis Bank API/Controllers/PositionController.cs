using Atlantis_Bank_API.DTOs;
using Atlantis_Bank_API.Mappers;
using Atlantis_Bank_BLL;
using Microsoft.AspNetCore.Mvc;

namespace Atlantis_Bank_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        [HttpGet("All")]
        public async Task<ActionResult<List<PositionDTO>>> GetAllPositions()
        {
            var dt = await clsPosition.GetAllPositions();

            return Ok(PositionMapper.ToDTOList(dt));
        }

        [HttpGet("{id}")]
        public ActionResult<PositionDTO> GetPositionByID(int id)
        {
            clsPosition position = clsPosition.Find(id);

            if (position == null)
                return NotFound();

            return Ok(PositionMapper.ToDTO(position));
        }
    }
}
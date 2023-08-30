using Atlet.Business.DTOs.Moves.MoveDtos;
using Atlet.Business.Services.Interfaces.Moves;
using Microsoft.AspNetCore.Mvc;

namespace Atlet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovesController : ControllerBase
    {
        private readonly IMoveService _moveService;

        public MovesController(IMoveService moveService)
        {
            _moveService = moveService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllMoves([FromQuery]string? search) {

            return Ok(await _moveService.GetAllMovesAsync(search));
        
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogCategoryById([FromRoute] int id)
        {
            return Ok(await _moveService.GetMoveByIdAsync(id));
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateMove([FromBody]MovePostDto movePostDto)
        {
            return Ok(await _moveService.CreateMoveAsync(movePostDto));
        }
        [HttpPut("")]
        public async Task<IActionResult> UpdateMove([FromBody]MovePutDto movePutDto)
        {
            return Ok(await _moveService.UpdateMoveAsync(movePutDto));
        }
        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteMove([FromRoute]int id)
        {
            return Ok(await _moveService.DeleteMoveAsync(id));
        }
        
    }
}

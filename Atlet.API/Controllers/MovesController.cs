﻿using Atlet.Business.DTOs.Moves.MoveDtos;
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
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllMoves([FromQuery]string? search) {

            return Ok(await _moveService.GetAllMovesAsync(search));
        
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetBlogCategoryById([FromRoute] int id)
        {
            return Ok(await _moveService.GetMoveByIdAsync(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMove([FromForm]MovePostDto movePostDto)
        {
            return Ok(await _moveService.CreateMoveAsync(movePostDto));
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateMove([FromForm]MovePutDto movePutDto)
        {
            return Ok(await _moveService.UpdateMoveAsync(movePutDto));
        }
        [HttpDelete("[action]/{id}")] 
        public async Task<IActionResult> DeleteMove([FromRoute]int id)
        {
            return Ok(await _moveService.DeleteMoveAsync(id));
        }
        
    }
}
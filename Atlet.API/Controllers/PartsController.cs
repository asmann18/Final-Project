﻿using Atlet.Business.DTOs.Moves.PartDtos;
using Atlet.Business.Services.Interfaces.Moves;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Atlet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PartsController : ControllerBase
{
    private readonly IPartService _partService;

    public PartsController(IPartService partService)
    {
        _partService = partService;
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllParts([FromQuery] string? search)
    {
        return Ok(await _partService.GetAllPartsAsync(search));
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetAllMovesByPartId([FromRoute] int id)
    {
        return Ok(await _partService.GetAllMovesByPartId(id));
    }
    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetBlogCategoryById([FromRoute] int id)
    {
        return Ok(await _partService.GetPartByIdAsync(id));
    }
    [HttpPost("[action]")]
    [Authorize(Roles = "Admin,Moderator")]
    public async Task<IActionResult> CreatePart([FromForm]PartPostDto partPostDto)
    {
        return Ok(await _partService.CreatePartAsync(partPostDto));
    }

    [HttpPut("[action]")]
    [Authorize(Roles = "Admin,Moderator")]
    public async Task<IActionResult> UpdatePart([FromForm]PartPutDto partPutDto)
    {
        return Ok(await _partService.UpdatePartAsync(partPutDto));
    }
    [HttpDelete("[action]/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeletePart([FromRoute]int id)
    {
        return Ok(await _partService.DeletePartAsync(id));
    }

    
}

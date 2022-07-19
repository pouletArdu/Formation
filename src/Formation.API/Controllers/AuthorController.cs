﻿using Formation.Application.Authors.Commands.Create;
using Formation.Application.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Formation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly ISender _mediator;

    public AuthorController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAuthorCommand request)
    {
        return await Send(request);
    }

    private async Task<IActionResult> Send<T>(IRequest<T> request)
    {
        try
        {
            return Ok(await _mediator.Send(request));
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors.Select(x => x.Value));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}

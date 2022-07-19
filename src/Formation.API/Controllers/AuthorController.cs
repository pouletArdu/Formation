using Formation.Application.Authors.Commands.Create;
using Formation.Application.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Formation.Application.Authors.Queries.GetOne;

namespace Formation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{

    private ISender _mediator = null!;

    public AuthorController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Add([FromBody] CreateAuthorCommand request)
    {
        return await SendAsync(request);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetOneAuthorById(int id)
    {
        return await SendAsync(new GetOneAuthorQuery
        {
            Id = id,
        });
    }

    private async Task<IActionResult> SendAsync<T>(IRequest<T> request)
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
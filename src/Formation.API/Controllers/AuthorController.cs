using Formation.Application.Authors.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

    [HttpPost]
    public async Task<ActionResult<int>> Add([FromBody] CreateAuthorCommand request)
    {
        return await _mediator.Send(request);
    }
}

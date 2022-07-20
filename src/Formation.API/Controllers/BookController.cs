using Formation.Application.Books.Commands.Create;
using Formation.Application.Books.Queries.GetOne;
using Formation.Application.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Formation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private ISender _mediator = null!;

        public BookController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBookCommand request)
        {
            return await Send(request);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            return await Send(new GetOneBookQuery(id));
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
}

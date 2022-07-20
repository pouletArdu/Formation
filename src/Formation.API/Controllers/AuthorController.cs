﻿using Formation.Application.Authors.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Formation.Application.Common.Exceptions;
using Formation.Application.Authors.Queries.GetOne;

namespace Formation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private ISender _mediator = null;

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

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            //AuthorDTO author;
            GetOneAuthorQuery authorQuery = new GetOneAuthorQuery(id);
            return await SendAsync(authorQuery);
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
}

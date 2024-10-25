using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newsy.Api.Extensions;
using Newsy.Api.Requests;
using Newsy.Api.Response;
using Newsy.Application.Commands;

namespace Newsy.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator) => _mediator = mediator;

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Register([FromBody] RegisterRequest request)
        {
            var command = new RegisterUserCommand(request.FirstName, request.LastName, request.Username, request.Email, request.Password);

            var commandResponse = await _mediator.Send(command);

            return StatusCode(commandResponse.StatusCode, commandResponse.ToApiResponse());
        }

        //TODO SG introduce a admin role
        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<LoginApiResponse>> Login([FromBody] LoginRequest request)
        {
            var command = new LoginUserCommand(request.Username, request.Password);

            var commandResponse = await _mediator.Send(command);

            return StatusCode(commandResponse.StatusCode, commandResponse.ToApiResponse());
        }
    }
}
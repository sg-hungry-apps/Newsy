using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newsy.Api.Extensions;
using Newsy.Api.Requests;
using Newsy.Api.Response;
using Newsy.Application.Commands;
using System.Net;
using System.Security.Claims;

namespace Newsy.Api.Controllers
{
    [ApiController]
    [Route("articles")]
    public class ArticlesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticlesController(IMediator mediator) => _mediator = mediator;

        //TODO SG is this supposed to be PATCH since we are updating the views?
        [HttpGet]
        [Route("article")]
        public async Task<ActionResult<GetArticleApiResponse>> GetArticle([FromQuery] Guid articleId)
        {
            var command = new GetArticleCommand(articleId);

            var commandResponse = await _mediator.Send(command);

            return StatusCode(commandResponse.StatusCode, commandResponse.ToApiResponse());
        }

        [HttpGet]
        [Route("by-author")]
        public async Task<ActionResult<GetArticlesApiResponse>> GetArticlesByAuthor([FromQuery] Guid authorId)
        {
            var command = new GetArticlesByAuthorCommand(authorId);

            var commandResponse = await _mediator.Send(command);

            return StatusCode(commandResponse.StatusCode, commandResponse.ToApiResponse());
        }

        //TODO SG do we limit the number for return articles or ask for number to be returned?
        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<GetArticlesApiResponse>> SearchArticles([FromQuery] SearchArticlesRequest request)
        {
            var command = new SearchArticlesCommand(request.AuthorFirstName, request.AuthorLastName, request.DateFrom, request.DateTo, request.Category);

            var commandResponse = await _mediator.Send(command);

            return StatusCode(commandResponse.StatusCode, commandResponse.ToApiResponse());
        }

        //TODO SG do I need to return the Guid for the new article? what would be the use?
        [Authorize]
        [HttpPost]
        [Route("article")]
        public async Task<ActionResult<ApiResponse>> SaveArticle([FromBody] SaveArticleRequest request)
        {
            var currentUserId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(currentUserId))
            {
                return StatusCode((int)HttpStatusCode.Unauthorized, new ApiResponse((int)HttpStatusCode.Unauthorized, new List<string>() { "User is not authorized" }));
            }

            var command = new SaveArticleCommand(currentUserId, request.Title, request.Content, request.Categories);

            var commandResponse = await _mediator.Send(command);

            return StatusCode(commandResponse.StatusCode, commandResponse.ToApiResponse());
        }

        [Authorize]
        [HttpPut]
        [Route("article")]
        public async Task<ActionResult<ApiResponse>> EditArticle([FromBody] EditArticleRequest request)
        {
            var currentUserId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(currentUserId))
            {
                return StatusCode((int)HttpStatusCode.Unauthorized, new ApiResponse((int)HttpStatusCode.Unauthorized, new List<string>() { "User is not authorized" }));
            }

            var command = new EditArticleCommand(request.ArticleId, currentUserId, request.Title, request.Content, request.Categories);

            var commandResponse = await _mediator.Send(command);

            return StatusCode(commandResponse.StatusCode, commandResponse.ToApiResponse());
        }

        //TODO SG custom authorize response
        [Authorize]
        [HttpDelete]
        [Route("article")]
        public async Task<ActionResult<ApiResponse>> DeleteArticle([FromQuery] Guid articleId)
        {
            var currentUserId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(currentUserId))
            {
                return StatusCode((int)HttpStatusCode.Unauthorized, new ApiResponse((int)HttpStatusCode.Unauthorized, new List<string>() { "User is not authorized" }));
            }

            var command = new DeleteArticleCommand(currentUserId, articleId);

            var commandResponse = await _mediator.Send(command);

            return StatusCode(commandResponse.StatusCode, commandResponse.ToApiResponse());
        }
    }
}
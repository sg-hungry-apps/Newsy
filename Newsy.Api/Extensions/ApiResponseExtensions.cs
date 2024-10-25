using Newsy.Api.Response;
using Newsy.Application.CommandResponses;
using Newsy.Domain.Models;

namespace Newsy.Api.Extensions
{
    public static class ApiResponseExtensions
    {
        public static GetArticleApiResponse ToApiResponse(this CommandResponse<Article> commandResponse)
        {
            return new GetArticleApiResponse(commandResponse.Payload, commandResponse.StatusCode, commandResponse.ErrorMessage);
        }

        public static GetArticlesApiResponse ToApiResponse(this CommandResponse<IEnumerable<Article>> commandResponse)
        {
            return new GetArticlesApiResponse(commandResponse.Payload, commandResponse.StatusCode, commandResponse.ErrorMessage);
        }

        public static LoginApiResponse ToApiResponse(this CommandResponse<string> commandResponse)
        {
            return new LoginApiResponse(commandResponse.Payload, commandResponse.StatusCode, commandResponse.ErrorMessage);
        }

        public static ApiResponse ToApiResponse(this CommandResponse commandResponse)
        {
            return new ApiResponse(commandResponse.StatusCode, commandResponse.ErrorMessage);
        }
    }
}

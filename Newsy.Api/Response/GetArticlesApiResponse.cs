using Newsy.Domain.Models;

namespace Newsy.Api.Response
{
    public class GetArticlesApiResponse : ApiResponse
    {
        public IEnumerable<Article> Articles { get; set; }

        public GetArticlesApiResponse(IEnumerable<Article> articles, int statusCode, IEnumerable<string> errorMessage) : base(statusCode, errorMessage)
        {
            Articles = articles;
        }
    }
}

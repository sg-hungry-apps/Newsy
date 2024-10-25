using Newsy.Domain.Models;

namespace Newsy.Api.Response
{
    public class GetArticleApiResponse : ApiResponse
    {
        public Article Article { get; set; }

        public GetArticleApiResponse(Article article, int statusCode, IEnumerable<string> errorMessage) : base(statusCode, errorMessage)
        {
            Article = article;
        }
    }
}
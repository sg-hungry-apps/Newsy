using MediatR;
using Newsy.Application.CommandResponses;
using Newsy.Domain.Models;

namespace Newsy.Application.Commands
{
    public class GetArticleCommand : IRequest<CommandResponse<Article>>
    {
        public Guid ArticleId { get; set; }

        public GetArticleCommand(Guid articleId)
        {
            ArticleId = articleId;
        }
    }
}
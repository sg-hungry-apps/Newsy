using MediatR;
using Newsy.Application.CommandResponses;

namespace Newsy.Application.Commands
{
    public class DeleteArticleCommand : IRequest<CommandResponse>
    {
        public string? UserId;

        public Guid ArticleId;

        public DeleteArticleCommand(string? userId, Guid articleId)
        {
            UserId = userId;
            ArticleId = articleId;
        }
    }
}
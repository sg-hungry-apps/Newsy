using MediatR;
using Newsy.Application.CommandResponses;
using Newsy.Domain.Models;

namespace Newsy.Application.Commands
{
    public class GetArticlesByAuthorCommand : IRequest<CommandResponse<IEnumerable<Article>>>
    {
        public Guid AuthorId { get; set; }

        public GetArticlesByAuthorCommand(Guid authorId)
        {
            AuthorId = authorId;
        }
    }
}
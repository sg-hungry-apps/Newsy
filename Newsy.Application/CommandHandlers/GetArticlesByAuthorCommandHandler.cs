using MediatR;
using Newsy.Application.CommandResponses;
using Newsy.Application.Commands;
using Newsy.Domain.Contracts.Queries;
using Newsy.Domain.Models;

namespace Newsy.Application.CommandHandlers
{
    public class GetArticlesByAuthorCommandHandler : IRequestHandler<GetArticlesByAuthorCommand, CommandResponse<IEnumerable<Article>>>
    {
        private IArticleQuery _articleQuery;

        public GetArticlesByAuthorCommandHandler(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public Task<CommandResponse<IEnumerable<Article>>> Handle(GetArticlesByAuthorCommand command, CancellationToken cancellationToken)
        {
            var articles = _articleQuery.GetArticlesByAuthor(command.AuthorId);
            if (articles != null && articles.Count() > 0)
            {
                return CommandResponse<IEnumerable<Article>>.SuccessfulResponse(articles);
            }

            return CommandResponse<IEnumerable<Article>>.NotFoundResponse("No articles found");
        }
    }
}
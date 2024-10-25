using MediatR;
using Newsy.Application.CommandResponses;
using Newsy.Application.Commands;
using Newsy.Domain.Contracts.Queries;
using Newsy.Domain.Models;

namespace Newsy.Application.CommandHandlers
{
    public class SearchArticlesCommandHandler : IRequestHandler<SearchArticlesCommand, CommandResponse<IEnumerable<Article>>>
    {
        private IArticleQuery _articleQuery;

        public SearchArticlesCommandHandler(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public Task<CommandResponse<IEnumerable<Article>>> Handle(SearchArticlesCommand command, CancellationToken cancellationToken)
        {
            var articles = _articleQuery.GetArticles(command.AuthorFirstName, command.AuthorLastName, command.DateFrom, command.DateTo, command.Category);

            return CommandResponse<IEnumerable<Article>>.SuccessfulResponse(articles);
        }
    }
}
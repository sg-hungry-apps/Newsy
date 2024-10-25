using MediatR;
using Newsy.Application.CommandResponses;
using Newsy.Application.Commands;
using Newsy.Domain.Contracts.Queries;
using Newsy.Domain.Contracts.Repositories;
using Newsy.Domain.Models;

namespace Newsy.Application.CommandHandlers
{
    public class GetArticleCommandHandler : IRequestHandler<GetArticleCommand, CommandResponse<Article>>
    {
        private IArticleQuery _articleQuery;
        private IArticleRepository _articleRepository;

        public GetArticleCommandHandler(IArticleQuery articleQuery, IArticleRepository articleRepository)
        {
            _articleQuery = articleQuery;
            _articleRepository = articleRepository;
        }

        public Task<CommandResponse<Article>> Handle(GetArticleCommand command, CancellationToken cancellationToken)
        {
            var article = _articleQuery.GetArticleById(command.ArticleId);
            if (article != null)
            {
                _articleRepository.UpdateArticleViews(article.Id);

                return CommandResponse<Article>.SuccessfulResponse(article);
            }

            return CommandResponse<Article>.NotFoundResponse("No article found");
        }
    }
}

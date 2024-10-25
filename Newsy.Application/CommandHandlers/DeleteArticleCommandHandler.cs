using MediatR;
using Newsy.Application.CommandResponses;
using Newsy.Application.Commands;
using Newsy.Domain.Contracts.Queries;
using Newsy.Domain.Contracts.Repositories;

namespace Newsy.Application.CommandHandlers
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, CommandResponse>
    {
        private IArticleRepository _articleRepository;
        private IArticleQuery _articleQuery;

        public DeleteArticleCommandHandler(IArticleRepository articleRepository, IArticleQuery articleQuery)
        {
            _articleRepository = articleRepository;
            _articleQuery = articleQuery;
        }

        public Task<CommandResponse> Handle(DeleteArticleCommand command, CancellationToken cancellationToken)
        {
            var article = _articleQuery.GetArticleById(command.ArticleId);

            if (article == null)
            {
                return CommandResponse.NotFoundResponse("Article was not found");
            }

            if (article.Author.Id.ToString() != command.UserId)
            {
                return CommandResponse.UnprocessableContentResponse("Logged-in user is not the owner of the article.");

            }

            _articleRepository.DeleteArticle(article.Id);

            return CommandResponse.SuccessfulResponse();
        }
    }
}

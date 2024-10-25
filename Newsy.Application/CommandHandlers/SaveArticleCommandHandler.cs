using MediatR;
using Newsy.Application.CommandResponses;
using Newsy.Application.Commands;
using Newsy.Domain.Contracts.Queries;
using Newsy.Domain.Contracts.Repositories;
using Newsy.Domain.Extensions;
using Newsy.Domain.Models;

namespace Newsy.Application.CommandHandlers
{
    public class SaveArticleCommandHandler : IRequestHandler<SaveArticleCommand, CommandResponse>
    {
        private IArticleRepository _articleRepository;
        private IUserQuery _userQuery;

        public SaveArticleCommandHandler(IArticleRepository articleRepository, IUserQuery userQuery)
        {
            _articleRepository = articleRepository;
            _userQuery = userQuery;
        }

        public Task<CommandResponse> Handle(SaveArticleCommand command, CancellationToken cancellationToken)
        {
            var author = _userQuery.GetUserById(Guid.Parse(command.UserId));

            if (author == null)
            {
                return CommandResponse.NotFoundResponse("Author not found.");
            }

            var newArticleId = Guid.NewGuid();
            var article = new Article
            {
                Id = newArticleId,
                Title = command.Title,
                Content = command.Content,
                PublishDate = DateOnly.FromDateTime(DateTime.Now),
                ViewCount = 0,
                Categories = command.Categories,
                Author = author.ToAuthor()
            };

            _articleRepository.SaveArticle(article);

            return CommandResponse.SuccessfulResponse();
        }
    }
}

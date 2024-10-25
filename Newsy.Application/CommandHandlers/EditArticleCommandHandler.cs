using MediatR;
using Newsy.Application.CommandResponses;
using Newsy.Application.Commands;
using Newsy.Domain.Contracts.Queries;
using Newsy.Domain.Contracts.Repositories;
using Newsy.Domain.Extensions;
using Newsy.Domain.Models;

namespace Newsy.Application.CommandHandlers
{
    public class EditArticleCommandHandler : IRequestHandler<EditArticleCommand, CommandResponse>
    {
        private IArticleRepository _articleRepository;
        private IArticleQuery _articleQuery;
        private IUserQuery _userQuery;

        public EditArticleCommandHandler(IArticleRepository articleRepository, IArticleQuery articleQuery, IUserQuery userQuery)
        {
            _articleRepository = articleRepository;
            _articleQuery = articleQuery;
            _userQuery = userQuery;
        }

        public Task<CommandResponse> Handle(EditArticleCommand command, CancellationToken cancellationToken)
        {
            var oldArticle = _articleQuery.GetArticleById(command.ArticleId);

            if (oldArticle == null)
            {
                return CommandResponse.NotFoundResponse("Article not found");
            }

            var author = _userQuery.GetUserById(Guid.Parse(command.UserId));

            if (author == null)
            {
                return CommandResponse.NotFoundResponse("Author not found.");
            }

            var newArticle = new Article
            {
                Id = oldArticle.Id,
                Title = command.Title,
                Content = command.Content,
                //TODO SG should we change this when editing or keep some other track to see changes made
                PublishDate = oldArticle.PublishDate,
                ViewCount = oldArticle.ViewCount,
                Categories = command.Categories,
                Author = author.ToAuthor()
            };

            _articleRepository.SaveArticle(newArticle);

            return CommandResponse.SuccessfulResponse();
        }
    }
}

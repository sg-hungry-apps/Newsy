using MediatR;
using Newsy.Application.CommandResponses;
using Newsy.Domain.Enums;

namespace Newsy.Application.Commands
{
    public class EditArticleCommand : IRequest<CommandResponse>
    {
        public Guid ArticleId { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public EditArticleCommand(Guid articleId, string userId, string title, string content, IEnumerable<Category> categories)
        {
            ArticleId = articleId;
            UserId = userId;
            Title = title;
            Content = content;
            Categories = categories;
        }
    }
}
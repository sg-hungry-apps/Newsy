using MediatR;
using Newsy.Application.CommandResponses;
using Newsy.Domain.Enums;

namespace Newsy.Application.Commands
{
    public class SaveArticleCommand : IRequest<CommandResponse>
    {
        public string UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public SaveArticleCommand(string userId, string title, string content, IEnumerable<Category> categories)
        {
            UserId = userId;
            Title = title;
            Content = content;
            Categories = categories;
        }
    }
}
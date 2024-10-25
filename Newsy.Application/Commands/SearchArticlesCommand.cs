using MediatR;
using Newsy.Application.CommandResponses;
using Newsy.Domain.Enums;
using Newsy.Domain.Models;

namespace Newsy.Application.Commands
{
    public class SearchArticlesCommand : IRequest<CommandResponse<IEnumerable<Article>>>
    {
        public string? AuthorFirstName { get; set; }

        public string? AuthorLastName { get; set; }

        public DateOnly? DateFrom { get; set; }

        public DateOnly? DateTo { get; set; }

        public Category? Category { get; set; }

        public SearchArticlesCommand(string? authorFirstName, string? authorLastName, DateOnly? dateFrom, DateOnly? dateTo, Category? category)
        {
            AuthorFirstName = authorFirstName;
            AuthorLastName = authorLastName;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Category = category;
        }
    }
}
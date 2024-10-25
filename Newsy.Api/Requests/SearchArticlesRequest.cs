using Newsy.Domain.Enums;

namespace Newsy.Api.Requests
{
    public class SearchArticlesRequest
    {
        public string? AuthorFirstName { get; set; }

        public string? AuthorLastName { get; set; }

        public DateOnly? DateFrom { get; set; }

        public DateOnly? DateTo { get; set; }

        public Category? Category { get; set; }
    }
}
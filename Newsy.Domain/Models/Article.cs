using Newsy.Domain.Enums;
namespace Newsy.Domain.Models
{
    public class Article
    {
        public Guid Id { get; set; }

        public required string Title { get; set; }

        public required string Content { get; set; }

        public DateOnly PublishDate { get; set; }

        public required Author Author { get; set; }

        public required IEnumerable<Category> Categories { get; set; }

        public int ViewCount { get; set; } = 0;
    }
}
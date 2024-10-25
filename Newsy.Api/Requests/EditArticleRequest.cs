using Newsy.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Newsy.Api.Requests
{
    public class EditArticleRequest
    {
        [Required]
        public Guid ArticleId { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Content { get; set; }

        [Required]
        public required IEnumerable<Category> Categories { get; set; }
    }
}

using Newsy.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Newsy.Api.Requests
{
    public class SaveArticleRequest
    {
        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Content { get; set; }

        [Required]
        public required IEnumerable<Category> Categories { get; set; }
    }
}

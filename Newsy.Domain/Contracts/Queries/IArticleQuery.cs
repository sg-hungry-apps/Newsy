using Newsy.Domain.Enums;
using Newsy.Domain.Models;

namespace Newsy.Domain.Contracts.Queries
{
    public interface IArticleQuery
    {
        IEnumerable<Article> GetArticles(string? authorFirstName, string? authorLastName, DateOnly? dateFrom, DateOnly? dateTo, Category? category);

        IEnumerable<Article> GetArticlesByAuthor(Guid authorId);

        Article? GetArticleById(Guid articleId);
    }
}
using Newsy.Domain.Contracts.Queries;
using Newsy.Domain.Enums;
using Newsy.Domain.Models;

namespace Newsy.Infrastructure.Queries
{
    public class ArticleQuery : IArticleQuery
    {
        public IEnumerable<Article> GetArticles(string? authorFirstName, string? authorLastName, DateOnly? dateFrom, DateOnly? dateTo, Category? category)
        {
            return TestData.Articles.Where(x => authorFirstName == null || x.Author.FirstName.ToLower().Contains(authorFirstName.ToLower()))
                            .Where(x => authorLastName == null || x.Author.LastName.ToLower().Contains(authorLastName.ToLower()))
                            .Where(x => dateFrom == null || dateFrom.Value.CompareTo(x.PublishDate) <= 0)
                            .Where(x => dateTo == null || dateTo.Value.CompareTo(x.PublishDate) > 0)
                            .Where(x => category == null || x.Categories.ToList().Contains((Category)category));
        }

        public IEnumerable<Article> GetArticlesByAuthor(Guid authorId)
        {
            return TestData.Articles.Where(x => x.Author.Id == authorId);
        }

        public Article? GetArticleById(Guid articleId)
        {
            return TestData.Articles.FirstOrDefault(x => x.Id == articleId);
        }
    }
}
using Newsy.Domain.Models;

namespace Newsy.Domain.Contracts.Repositories
{
    public interface IArticleRepository
    {
        void SaveArticle(Article article);

        void UpdateArticleViews(Guid articleId);

        void DeleteArticle(Guid articleId);
    }
}
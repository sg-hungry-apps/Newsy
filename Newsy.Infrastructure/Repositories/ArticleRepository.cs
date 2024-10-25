using Newsy.Domain.Contracts.Repositories;
using Newsy.Domain.Models;

namespace Newsy.Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        public void SaveArticle(Article article)
        {
            var index = TestData.Articles.FindIndex(x => x.Id == article.Id);

            if (index < 0)
            {
                TestData.Articles.Add(article);
            }
            else
            {
                //TODO SG do we want to have a specific EditArticle method? depends on the DB that we use maybe
                TestData.Articles[index] = article;
            }
        }

        public void UpdateArticleViews(Guid articleId)
        {
            var article = TestData.Articles.FirstOrDefault(x => x.Id == articleId);

            if (article != null)
            {
                article.ViewCount++;
            }
        }

        public void DeleteArticle(Guid articleId)
        {
            var article = TestData.Articles.FirstOrDefault(x => x.Id == articleId);

            if (article != null)
            {
                TestData.Articles.Remove(article);
            }
        }
    }
}

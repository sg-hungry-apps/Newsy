using Microsoft.Extensions.DependencyInjection;
using Newsy.Domain.Contracts.Queries;
using Newsy.Infrastructure.Queries;

namespace Newsy.Infrastructure.Bootstrapping
{
    public static class QueryExtensions
    {
        public static void AddQueries(this IServiceCollection services)
        {
            services.AddScoped<IArticleQuery, ArticleQuery>();
            services.AddScoped<IUserQuery, UserQuery>();
        }
    }
}
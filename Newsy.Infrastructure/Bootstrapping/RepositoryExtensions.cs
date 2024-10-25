using Microsoft.Extensions.DependencyInjection;
using Newsy.Domain.Contracts.Repositories;
using Newsy.Infrastructure.Repositories;

namespace Newsy.Infrastructure.Bootstrapping
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
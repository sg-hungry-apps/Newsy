using Newsy.Domain.Models;

namespace Newsy.Domain.Extensions
{
    public static class UserExtensions
    {
        public static Author ToAuthor(this User user)
        {
            return new Author { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName };
        }
    }
}
using Newsy.Domain.Models;

namespace Newsy.Domain.Contracts.Queries
{
    public interface IUserQuery
    {
        User? GetUser(string username, string password);

        User? GetUserById(Guid id);

        bool CheckIfUsernameExists(string username);

        bool CheckIfEmailExists(string email);
    }
}
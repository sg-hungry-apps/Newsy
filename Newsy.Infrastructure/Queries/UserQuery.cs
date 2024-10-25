using Newsy.Domain.Contracts.Queries;
using Newsy.Domain.Models;

namespace Newsy.Infrastructure.Queries
{
    public class UserQuery : IUserQuery
    {
        public User? GetUser(string username, string password)
        {
            return TestData.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        public User? GetUserById(Guid id)
        {
            return TestData.Users.FirstOrDefault(x => x.Id == id);
        }

        public bool CheckIfEmailExists(string email)
        {
            return TestData.Users.Exists(x => x.Email.Trim().ToLower() == email.Trim().ToLower());
        }

        public bool CheckIfUsernameExists(string username)
        {
            return TestData.Users.Exists(x => x.Username.Trim().ToLower() == username.Trim().ToLower());
        }
    }
}

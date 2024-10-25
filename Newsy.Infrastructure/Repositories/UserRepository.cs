using Newsy.Domain.Contracts.Repositories;
using Newsy.Domain.Models;

namespace Newsy.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void RegisterUser(string firstName, string lastName, string username, string email, string password)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Email = email,
                Password = password
            };

            TestData.Users.Add(newUser);
        }
    }
}
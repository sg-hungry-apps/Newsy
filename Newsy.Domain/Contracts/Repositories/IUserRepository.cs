namespace Newsy.Domain.Contracts.Repositories
{
    public interface IUserRepository
    {
        void RegisterUser(string firstName, string lastName, string username, string email, string password);
    }
}
using MediatR;
using Newsy.Application.CommandResponses;

namespace Newsy.Application.Commands
{
    public class RegisterUserCommand : IRequest<CommandResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public RegisterUserCommand(string firstName, string lastName, string username, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Password = password;
        }
    }
}
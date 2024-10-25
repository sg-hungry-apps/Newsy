using MediatR;
using Newsy.Application.CommandResponses;

namespace Newsy.Application.Commands
{
    public class LoginUserCommand : IRequest<CommandResponse<string>>
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public LoginUserCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
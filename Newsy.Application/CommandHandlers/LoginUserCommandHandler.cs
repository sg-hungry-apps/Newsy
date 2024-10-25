using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newsy.Application.CommandResponses;
using Newsy.Application.Commands;
using Newsy.Domain.Contracts.Queries;
using Newsy.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Newsy.Application.CommandHandlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, CommandResponse<string>>
    {
        private IUserQuery _userQuery;
        private IConfiguration _config;

        public LoginUserCommandHandler(IUserQuery userQuery, IConfiguration config)
        {
            _userQuery = userQuery;
            _config = config;
        }

        public Task<CommandResponse<string>> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var user = _userQuery.GetUser(command.Username, command.Password);

            if (user == null)
            {
                return CommandResponse<string>.NotFoundResponse("User was not found.");
            }

            return CommandResponse<string>.SuccessfulResponse(GenerateJSONWebToken(user));
        }

        private string GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
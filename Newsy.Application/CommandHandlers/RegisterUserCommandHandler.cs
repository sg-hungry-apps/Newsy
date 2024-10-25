using MediatR;
using Newsy.Application.CommandResponses;
using Newsy.Application.Commands;
using Newsy.Domain.Contracts.Queries;
using Newsy.Domain.Contracts.Repositories;

namespace Newsy.Application.CommandHandlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, CommandResponse>
    {
        private IUserQuery _userQuery;
        private IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserQuery userQuery, IUserRepository userRepository)
        {
            _userQuery = userQuery;
            _userRepository = userRepository;
        }

        public Task<CommandResponse> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var validationResponse = ValidateUserInformation(command.Username, command.Email);

            if (validationResponse.Count > 0)
            {
                return CommandResponse.UnprocessableContentResponse(validationResponse);
            }

            _userRepository.RegisterUser(command.FirstName, command.LastName, command.Username, command.Email, command.Password);

            return CommandResponse.SuccessfulResponse();
        }

        private List<string> ValidateUserInformation(string username, string email)
        {
            var errorMessages = new List<string>();

            if (_userQuery.CheckIfUsernameExists(username))
            {
                errorMessages.Add("User with that username already exists");
            }

            if (_userQuery.CheckIfEmailExists(email))
            {
                errorMessages.Add("User with that email already exists");
            }

            return errorMessages;
        }
    }
}

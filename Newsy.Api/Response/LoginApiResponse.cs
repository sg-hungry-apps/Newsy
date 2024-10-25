namespace Newsy.Api.Response
{
    public class LoginApiResponse : ApiResponse
    {
        public string Token { get; set; }

        public LoginApiResponse(string token, int statusCode, IEnumerable<string> errorMessage) : base(statusCode, errorMessage)
        {
            Token = token;
        }
    }
}
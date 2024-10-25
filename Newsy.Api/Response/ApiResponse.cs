namespace Newsy.Api.Response
{
    public class ApiResponse
    {
        //TODO SG add correlation ID either here or in the response headers

        public List<string>? ErrorMessage { get; set; }

        public int StatusCode { get; set; }

        public ApiResponse(int statusCode, IEnumerable<string>? errorMessages)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessages?.ToList();
        }
    }
}

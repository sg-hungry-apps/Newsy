using Newsy.Api.Response;

namespace Newsy.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception)
            {
                //TODO SG log the error

                var errorResponse = new ApiResponse(StatusCodes.Status500InternalServerError, new List<string>() { "Server Error" });

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
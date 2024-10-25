using Microsoft.AspNetCore.Mvc;
using Newsy.Api.Middleware;
using Newsy.Api.Response;
using Newsy.Application.CommandHandlers;
using Newsy.Infrastructure.Bootstrapping;
using System.Net;
using System.Text.Json.Serialization;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<SearchArticlesCommandHandler>());
        builder.Services.AddQueries();
        builder.Services.AddRepositories();
        builder.Services.AddJwtAuthentication(builder.Configuration);
        builder.Services.AddSwagger();

        //TODO SG move this to an extension method
        builder.Services.AddMvc()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var errors = actionContext.ModelState.Values.SelectMany(e => e.Errors.Select(m => m.ErrorMessage)).ToList();

                var apiResponse = new ApiResponse((int)HttpStatusCode.BadRequest, errors);

                return new BadRequestObjectResult(apiResponse);
            };
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.AddSwagger();
        }

        //TODO SG add middleware for defending against XSS or SQL attacks
        //TOOD SG add middleware for checking request headers and response headers
        app.UseMiddleware<ExceptionMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
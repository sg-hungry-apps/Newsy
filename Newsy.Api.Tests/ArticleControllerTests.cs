using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Newsy.Api.Response;
using FluentAssertions;
using Newsy.Api.Requests;
using Newtonsoft.Json;

namespace Newsy.Api.Tests
{
    public class ArticleControllerTests
    {
        [Fact]
        public async Task Given_ArticleExists_Then_GetArticleReturnsOk()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var response = await client.GetAsync("/articles/article?articleId=832db140-6eb2-417a-b699-792ab02f0233");

            var responseContent = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<GetArticleApiResponse>(responseContent);

            apiResponse.Should().NotBeNull();
            apiResponse?.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task Given_ArticleDoesNotExists_Then_GetArticleReturnsNotFound()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var response = await client.GetAsync("/articles/article?articleId=202db140-6eb2-417a-b699-792ab02f0233");

            var responseContent = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<GetArticleApiResponse>(responseContent);

            apiResponse.Should().NotBeNull();
            apiResponse?.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
            apiResponse?.ErrorMessage.Should().Contain("No article found");
        }

        [Fact]
        public async Task Given_UserIsNotAuthorized_Then_DeleteArticleReturnsUnauthorized()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var response = await client.DeleteAsync("/articles/article?articleId=202db140-6eb2-417a-b699-792ab02f0233");

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task Given_ArticleDoesNotExists_Then_DeleteArticleReturnsNotFound()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + "users/login");
            requestMessage.Content = JsonContent.Create(new LoginRequest { Username = "Author1", Password = "AuthorPassword1" });

            var loginResponse = await client.SendAsync(requestMessage);
            var logindResponseContent = await loginResponse.Content.ReadAsStringAsync();
            var loginApiResponse = JsonConvert.DeserializeObject<LoginApiResponse>(logindResponseContent);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginApiResponse.Token);

            var response = await client.DeleteAsync("/articles/article?articleId=202db140-6eb2-417a-b699-792ab02f0233");

            var responseContent = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseContent);

            apiResponse.Should().NotBeNull();
            apiResponse?.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
            apiResponse?.ErrorMessage.Should().Contain("Article was not found");
        }

        [Fact]
        public async Task Given_UserIsNotTheAuthor_Then_DeleteArticleReturnsUnprocessableContent()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + "users/login");
            requestMessage.Content = JsonContent.Create(new LoginRequest { Username = "Author1", Password = "AuthorPassword1" });

            var loginResponse = await client.SendAsync(requestMessage);
            var logindResponseContent = await loginResponse.Content.ReadAsStringAsync();
            var loginApiResponse = JsonConvert.DeserializeObject<LoginApiResponse>(logindResponseContent);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginApiResponse.Token);

            var response = await client.DeleteAsync("/articles/article?articleId=cedc56c5-eab6-4e16-a2f4-083124d7df24");

            var responseContent = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseContent);

            apiResponse.Should().NotBeNull();
            apiResponse?.StatusCode.Should().Be((int)HttpStatusCode.UnprocessableContent);
            apiResponse?.ErrorMessage.Should().Contain("Logged-in user is not the owner of the article.");
        }
    }
}
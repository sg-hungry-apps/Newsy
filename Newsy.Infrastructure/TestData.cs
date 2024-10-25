using Newsy.Domain.Enums;
using Newsy.Domain.Models;

namespace Newsy.Infrastructure
{
    //TODO SG using this static class just to be show how the API works
    //TODO SG use database for the future and also add a database extensions for setting everything up in the bootstrapping folder
    public static class TestData
    {
        public static List<User> Users =
        [
            new()
            {
                Id = Guid.Parse("4c556655-cf22-4696-bbfd-3c7d764acf57"),
                FirstName = "AuthorFirstName1",
                LastName = "AuthorLastName1",
                Email = "AuthorEmail1",
                Password = "AuthorPassword1",
                Username = "Author1"
            },
            new()
            {
                Id = Guid.Parse("fcd19768-95e5-4063-a781-a46e268f5edb"),
                FirstName = "AuthorFirstName2",
                LastName = "AuthorLastName2",
                Email = "AuthorEmail2",
                Password = "AuthorPassword2",
                Username = "Author2"
            },
            new()
            {
                Id = Guid.Parse("bcf53d69-bade-4095-9769-d0f965a615b4"),
                FirstName = "AuthorFirstName3",
                LastName = "AuthorLastName3",
                Email = "AuthorEmail3",
                Password = "AuthorPassword3",
                Username = "Author3"
            },
            new()
            {
                Id = Guid.Parse("0bb7d57e-5937-4fba-bfa3-c75d0b4eddd0"),
                FirstName = "UserFirstName4",
                LastName = "UserLastName4",
                Email = "UserEmail4",
                Password = "UserPassword4",
                Username = "User4"
            }
        ];

        public static List<Author> Authors =
        [
            new()
            {
                Id = Guid.Parse("4c556655-cf22-4696-bbfd-3c7d764acf57"),
                FirstName = "AuthorFirstName1",
                LastName = "AuthorLastName1"
            },
            new()
            {
                Id = Guid.Parse("fcd19768-95e5-4063-a781-a46e268f5edb"),
                FirstName = "AuthorFirstName2",
                LastName = "AuthorLastName2"
            },
            new()
            {
                Id = Guid.Parse("bcf53d69-bade-4095-9769-d0f965a615b4"),
                FirstName = "AuthorFirstName3",
                LastName = "AuthorLastName3"
            }
        ];

        public static List<Article> Articles =
        [
            new()
            {
                Id = Guid.Parse("832db140-6eb2-417a-b699-792ab02f0233"),
                PublishDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                Title = "Random article 1",
                Content = "Content of random article 1",
                Author = Authors[0],
                Categories = new List<Category>()
                {
                    Category.Business,
                    Category.Politics
                },
                ViewCount = 10
            },
            new()
            {
                Id = Guid.Parse("a854820f-ff7a-4c5d-8659-bebd98bd486f"),
                PublishDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)),
                Title = "Random article 2",
                Content = "Content of random article 2",
                Author = Authors[0],
                Categories = new List<Category>()
                {
                    Category.Business
                },
                ViewCount = 100
            },
            new()
            {
                Id = Guid.Parse("cedc56c5-eab6-4e16-a2f4-083124d7df24"),
                PublishDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-10)),
                Title = "Random article 3",
                Content = "Content of random article 3",
                Author = Authors[1],
                Categories = new List<Category>()
                {
                    Category.Sports
                },
                ViewCount = 1000
            }
        ];
    }
}
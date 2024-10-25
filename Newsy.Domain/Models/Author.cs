﻿namespace Newsy.Domain.Models
{
    public class Author
    {
        public Guid Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }
    }
}
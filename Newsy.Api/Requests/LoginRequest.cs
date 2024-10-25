﻿using System.ComponentModel.DataAnnotations;

namespace Newsy.Api.Requests
{
    public class LoginRequest
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
using System;
using MKANTajneedSystem.Enum;

namespace MKANTajneedSystem.Models
{
    public record MemberDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public IsBornAhmadi IsBornAhmadi { get; set; }
    }
}
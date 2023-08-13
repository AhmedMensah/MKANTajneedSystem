using MKANTajneedSystem.Enum;

namespace MKANTajneedSystem.Models
{
    public record MemberUpdateDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
    }
}
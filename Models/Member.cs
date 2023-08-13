using MKANTajneedSystem.Enum;

namespace MKANTajneedSystem
{
  public class Member
    {
        public int Id { get; set; }
        public string MemberCode { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public IsBornAhmadi IsBornAhmadi { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }  
}
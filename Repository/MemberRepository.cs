using System.ComponentModel.Design;
using MKANTajneedSystem.Models;
using MKANTajneedSystem.Shared;

namespace MKANTajneedSystem.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public List<Member> members = new List<Member>();

        public Member Create(MemberDto request)
        {
            int id = members.Count != 0 ? members[members.Count - 1].Id + 1 : 1;
            string code = Helper.GenerateCode(id);

            var member = new Member
            {
                Id = id,
                MemberCode = code,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                AgeGroup = Helper.SetAgeGroup(),
                IsBornAhmadi = request.IsBornAhmadi,
                Created = DateTime.Now
            };

            return member;
        }

        public List<Member> GetAllMembers()
        {
            return members;
        }

        public Member FindById(int id)
        {
            return members.Find(x => x.Id == id)!;
        }

        public Member FindByCode(string code)
        {
            return member.Find(x => x.MemberCode == code)!;
        }

        public Member FindByEmail(string email)
        {
            return members.Find(x => x.Email == email)!;
        }
    }
}
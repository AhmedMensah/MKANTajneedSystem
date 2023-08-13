using MKANTajneedSystem.Models;

namespace MKANTajneedSystem.Repository
{
    public interface IMemberRepository
    {
        Member Create(MemberDto request);
        List<Member> GetAllMembers();
        Member FindById(int id);
        Member FindByCode(string code);
        Member FindByEmail(string email);
    }
}
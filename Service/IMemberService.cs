using MKANTajneedSystem.Models;

namespace MKANTajneedSystem.Service
{
    public interface IMemberService
    {
        void CreateMember(MemberDto request);
        void GetAllMembers();
        void ViewMember();
        void UpdateMember(MemberUpdateDto request);
        void DeleteMember();
    }
}
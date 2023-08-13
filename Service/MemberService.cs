using System;
using ConsoleTables;
using MKANTajneedSystem.Constants;
using MKANTajneedSystem.Enum;
using MKANTajneedSystem.Models;
using MKANTajneedSystem.Repository;
using MKANTajneedSystem.Shared;

namespace MKANTajneedSystem.Service
{
    public class MemberService : IMemberService
    {
        private readonly MemberRepository _repository; // DI stands for Dependency Injection

        public MemberService(MemberRepository repository)
        {
            _repository = repository;
        }

        public void CreateMember(MemberDto request)
        {
            try
            {
                Console.Write("Enter firstname: ");
                request.FirstName = Console.ReadLine()!;

                Console.Write("Enter lastname: ");
                request.LastName = Console.ReadLine()!;

                Console.Write("Enter middlename: ");
                request.MiddleName = Console.ReadLine();

                Console.Write("Enter email address: ");
                request.Email = Console.ReadLine()!;

                Console.Write("Enter date of birth (2003-12-25): ");
                var dob = Helper.TryParseDateOnly(Console.ReadLine()!);
                request.DateOfBirth = dob;

                var findMember = _repository.FindByEmail(request.Email);

                if (findMember is not null)
                {
                    Console.WriteLine($"Record with {findMember.Email} already exist!");
                    return;
                }

                var member = _repository.Create(request);

                _repository.members.Add(employee);
                Console.WriteLine($"Record with `{request.Email}` created successfully");

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        public void GetAllMembers()
        {
            try
            {
                if (_repository.members.Count != 0)
                {
                    var table = new ConsoleTable("Id", "Member Code", "Firstname", "Lastname", "Date Joined");

                    foreach (var member in _repository.members)
                    {
                        table.AddRow(member.Id, member.MemberCode, member.FirstName, member.LastName, member.DateJoined);
                    }

                    table.Write(Format.Alternative);

                    return;
                }

                Console.WriteLine(Messages.NORECORDSFOUND);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteMember()
        {
            try
            {
                Console.Write("Enter member code of member to delete: ");
                string code = Console.ReadLine()!;
                var member = _repository.FindByCode(code);

                if (member is not null)
                {
                    _repository.employees.Remove(member);
                    Console.WriteLine(Messages.RECORDREMOVED);
                    return;
                }

                Console.WriteLine(Messages.NOTFOUND);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateMember(MemberUpdateDto request)
        {
            try
            {
                Console.Write("Enter ID for member to update record: ");
                int id = int.Parse(Console.ReadLine()!);
                var member = _repository.FindById(id);

                if (member is not null)
                {
                    Console.Write("Enter new firstname: ");
                    member.FirstName = request.FirstName = Console.ReadLine()!;

                    Console.Write("Enter new lastname: ");
                    member.LastName = request.LastName = Console.ReadLine()!;

                    Console.Write("Enter new middlename: ");
                    member.MiddleName = request.MiddleName = Console.ReadLine()!;

                    member.Modified = DateTime.Now;

                    Console.WriteLine(Messages.RECORDUPDATED);
                    return;
                }

                Console.WriteLine(Messages.NOTFOUND);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ViewMember()
        {
            try
            {
                Console.Write("Enter member code to search: ");
                string code = Console.ReadLine()!;

                var member = _repository.FindByCode(code);

                if (member is not null)
                {
                    PrintMemberDetail(member);
                    return;
                }

                Console.WriteLine(Messages.NOTFOUND);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void PrintMemberDetail(Member member)
        {
            Console.WriteLine(
            $@"Id: {member.Id}
            Member Code: {member.MemberCode}
            Firstname: {member.FirstName}
            Lastname: {member.LastName}
            Middlename: {member.MiddleName}
            Email: {member.Email}
            Date Of Birth: {member.DateOfBirth.ToShortDateString()}"
            );
        }
    }
}
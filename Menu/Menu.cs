using MKANTajneedSystem.Service;
using MKANTajneedSystem.Models;

namespace MKANTajneedSystem.Menu
{
    public class Menu
    {
        public static void MainMenu(IMemberService memberService)
        {
            bool flag = true;
            var MemberDto = new MemberDto();
            var updateMemberDto = new MemberUpdateDto();

            try
            {
                while (flag)
                {
                    PrintMenu();
                    Console.Write("\nPlease enter your preferred option: ");
                    string option = Console.ReadLine()!;

                    switch (option.ToLower())
                    {
                        case "1":
                            memberService.CreateMember(memberDto);
                            Console.WriteLine("");
                            break;
                        case "2":
                            memberService.GetAllMembers();
                            Console.WriteLine("");
                            break;
                        case "3":
                            memberService.ViewMember();
                            Console.WriteLine("");
                            break;
                        case "4":
                            memberService.UpdateMember(updateMemberDto);
                            Console.WriteLine("");
                            break;
                        case "5":
                            memberService.DeleteMember();
                            Console.WriteLine("");
                            break;
                        case "0":
                            flag = false;
                            break;
                        default:
                            throw new InvalidOperationException("Unknown operation!");
                    }
                }
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Enter 1 to Add new Member");
            Console.WriteLine("Enter 2 to View all Members");
            Console.WriteLine("Enter 3 to View a Member");
            Console.WriteLine("Enter 4 to Update a Member");
            Console.WriteLine("Enter 5 to Delete a Member");
            Console.WriteLine("Enter 0 to exit application");
        }
    }
}
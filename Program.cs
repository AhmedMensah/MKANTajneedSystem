using System.ComponentModel.Design;
using MKANTajneedSystem.Menu;
using MKANTajneedSystem.Repository;
using MKANTajneedSystem.Service;
using MKANTajneedSystem.Shared;
// Be able to Create an member record
// Be able to update an member record
// Be able to find member by member code
// Be able to find member by Id or member code
// Be able to remove/delete member record
// Be able to list all member records (Fetch all)


// DTO - Data Tranfer Object

// A class can inherit (or extend) another class, 
// A class can also implement more than one interface



// int[] number = { 0, 1, 5, 7, 10 };

// var lastIndex = number.Length - 1;

// var lastValue = number[number.Length - 1];

// Console.WriteLine($"Last Index: {lastIndex}");
// Console.WriteLine($"Last Value: {lastValue}");

Console.WriteLine("=========Employee Data Management Application (EDMA)==========");
var repository = new MemberRepository();
var memberService = new MemberService(repository);
Menu.MainMenu(memberService);

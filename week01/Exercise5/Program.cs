using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int numberSquare = SquareNumber(number);
        DisplayResult(numberSquare, name);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        string userName = Console.ReadLine();
        return userName;
    }

    static int PromptUserNumber()
    {
        Console.Write("What is your favorite number? ");
        int userNumber = int.Parse(Console.ReadLine());
        return userNumber;
    }

    static int SquareNumber(int userNumber)
    {
        int userSquare = userNumber * userNumber;
        return userSquare;
    }

    static void DisplayResult(int userSquare, string userName)
    {
        Console.WriteLine($"{userName}, the square of your number is {userSquare}");
    }

}
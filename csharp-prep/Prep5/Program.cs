using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string username = Console.ReadLine();
        return username;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    
    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write("Please enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string username, int square, int birthYear)
    {
        // Calculate how many years old the user turn this year
        int turnAge = DateTime.Now.Year - birthYear;

        Console.WriteLine($"{username}, the square of your favorite number is {square}.");
        Console.WriteLine($"{username}, you will turn {turnAge} this year.");
    }
    static void Main(string[] args)
    {
        // Welcome to the program
        DisplayWelcome();

        int birthYear;
        // Prompt for user information
        string username = PromptUserName();
        int number = PromptUserNumber();
        PromptUserBirthYear(out birthYear);

        DisplayResult(username, SquareNumber(number), birthYear);
    }
}
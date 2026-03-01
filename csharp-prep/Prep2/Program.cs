using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        // Prompt user for the grade
        Console.Write("Enter grade percentage: ");
        int grade_percent = int.Parse(Console.ReadLine());

        string letter = "";

        if (grade_percent >= 90)
        {
            letter = "A";
        }
        else if (grade_percent >= 80)
        {
            letter = "B";
        }
        else if (grade_percent >= 70)
        {
            letter = "C";
        }
        else if (grade_percent >= 60)
        {
            letter = "D";
        }
        else if (grade_percent < 60)
        {
            letter = "F";
        }

        // Add '+' or '-' to grade if necessary
        if (grade_percent > 60 && grade_percent < 93)
        {
            int ones_digit = grade_percent % 10;
            
            if (ones_digit >= 7)
            {
                letter += "+";
            }
            else if (ones_digit < 3)
            {
                letter += "-";
            }
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (grade_percent >= 70)
        {
            Console.WriteLine("Congratulations, you pass!");
        } else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}
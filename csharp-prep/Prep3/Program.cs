using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magic_number = randomGenerator.Next(1,100);

        int guesses = 0;

        while (true)
        {
            Console.Write("What is your guess? ");
            int guess = int.Parse(Console.ReadLine());

            guesses++;

            if (guess == magic_number)
            {
                Console.WriteLine("You found it!");

                if (guesses == 1)
                    Console.WriteLine($"It took you 1 guess.");
                else
                    Console.WriteLine($"It took you {guesses} guesses.");

                Console.Write("Do you want to play again? ");
                if (Console.ReadLine().ToLower() != "yes")
                {
                    break;
                }

                guesses = 0;
                magic_number = randomGenerator.Next(1,100);
            }
            else if (guess < magic_number)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magic_number)
            {
                Console.WriteLine("Lower");
            }
        }
    }
}
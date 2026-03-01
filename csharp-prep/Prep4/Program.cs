using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers. Enter 0 when done");
        List<int> numbers = new List<int>();

        while (true)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                break;
            }

            numbers.Add(number);
        }

        int sum = 0;
        float average = 0;
        int max = 0;
        int smallest_pos = -1;
        foreach (int number in numbers)
        {
            sum += number;
            average += (float)number / numbers.Count;

            if (max < number)
                max = number;
            if (number > 0 && (number < smallest_pos || smallest_pos == -1))
                smallest_pos = number;
        }

        numbers.Sort();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {smallest_pos}");
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
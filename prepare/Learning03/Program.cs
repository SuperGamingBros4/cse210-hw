using System;

class Program
{
    static void Main(string[] args)
    {
        // Verify fraction representation methods:
        Fraction frac1 = new Fraction();
        Console.WriteLine(frac1.GetFractionString());
        Console.WriteLine(frac1.GetDecimalValue());

        Fraction frac2 = new Fraction(2);
        Console.WriteLine(frac2.GetFractionString());
        Console.WriteLine(frac2.GetDecimalValue());

        Fraction frac3 = new Fraction(4, 5);
        Console.WriteLine(frac3.GetFractionString());
        Console.WriteLine(frac3.GetDecimalValue());

        Fraction frac4 = new Fraction(2, 3);
        Console.WriteLine(frac4.GetFractionString());
        Console.WriteLine(frac4.GetDecimalValue());

        Fraction frac5 = new Fraction(10, 0);
        Console.WriteLine(frac5.GetFractionString());
        Console.WriteLine(frac5.GetDecimalValue());

        // Test the setter methods:
        Fraction frac = new Fraction();
        Random rand = new Random();
        for (int i = 1; i <= 20; i++)
        {
            // Get random numbers for top and bottom
            int top = rand.Next(1, 50);
            int bottom = rand.Next(1, 50);
            
            // Set the top and bottom
            frac.SetTop(top);
            frac.SetBottom(bottom);

            // Display the fraction on a line
            Console.WriteLine($"Fraction {i}: string: {frac.GetFractionString()} Number: {frac.GetDecimalValue()}");
        }
    }
}
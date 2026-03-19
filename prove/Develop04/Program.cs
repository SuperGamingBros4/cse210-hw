using System;

class Program
{
    static void ShowMenu()
    {
        Console.WriteLine("Menu options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflecting activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. Quit");

        Console.Write("Select and option from the menu: ");
    }

    static void Main(string[] args)
    {
        // Create the activities
        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectingActivity reflectingActivity = new ReflectingActivity();
        ListingActivity listingActivity = new ListingActivity();

        bool running = true;
        
        while (running)
        {
            // Clear the console before displaying the menu
            Console.Clear();

            // Display the options to the user
            ShowMenu();

            // Get the input from the user
            string input = Console.ReadLine();

            // Do the action the user chose from the menu
            switch (input.ToLower())
            {
                case "1":
                    breathingActivity.Start();
                    break;
                case "2":
                    reflectingActivity.Start();
                    break;
                case "3":
                    listingActivity.Start();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    break;
            }
        }
    }
}
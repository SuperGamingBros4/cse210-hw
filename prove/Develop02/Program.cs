using System;

/*
 *
 *  Creativity and exceeding requirements:
 *  I made it so that the file is saved in CSV format and loaded again in a way that is robust to a lot of edge-cases.
 *  I also added error handling for loading a file so that the program does not crash if the file isn't loaded.
 *  I addition, I added the ability to edit journal entries because I kept making mistakes when entering a response.
 *
 */

class Program
{
    static string GetUserChoice()
    {
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Edit");
        Console.WriteLine("6. Quit");
        Console.Write("What would you like to do? ");

        return Console.ReadLine();
    }
    static string GetFilename()
    {
        Console.WriteLine("Enter filename");
        return Console.ReadLine();
    }
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        bool running = true;
        while (running)
        {
            switch (GetUserChoice())
            {
                // Write
                case "1":
                    journal.AddEntry();
                    break;
                // Display
                case "2":
                    journal.Display();
                    break;
                // Load
                case "3":
                    journal.LoadFromFile(GetFilename());
                    break;
                // Save
                case "4":
                    journal.SaveToFile(GetFilename());
                    break;
                case "5":
                    journal.EditEntry();
                    break;
                // Quit
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("That is not an option.");
                    break;
            }
        }
    }
}
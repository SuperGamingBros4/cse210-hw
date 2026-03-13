using System;
using System.Collections.Generic;

class Program
{
    static void MemorizeScripture(Scripture scripture)
    {
        while (true)
        {
            // Clear the console
            Console.Clear();

            // Display the scripture
            scripture.Display();
            Console.WriteLine();

            // Prompt the user and collect their input
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (scripture.IsFullyHidden())
            {
                // Exit if the scripture is fully hidden
                break;
            }

            if (input == "")
            {
                // Hide 3 random words from the scripture
                scripture.HideRandomWords(3);
            }
            else if (input.ToLower() == "quit")
            {
                // Exit the application if the user enters 'quit'
                break;
            }
        }

        // Unhide the words in the scripture when finished.
        scripture.UnHide();
    }
    static void Main(string[] args)
    {
        // Read the "scriptures.csv" file
        CSVReader reader = new CSVReader("scriptures.csv");
        List<Scripture> scriptures = new List<Scripture>();

        // Loop through each row in the CSV file except the header
        foreach (List<string> row in reader.ReadAllRows().Skip(1))
        {
            // Create a scripture from the reference and the scripture body
            Scripture readScripture = new Scripture(row[0], row[1]);

            // Add the scripture into the list
            scriptures.Add(readScripture);
        }

        // Close the file
        reader.Close();

        // Create a new Random object
        Random random = new Random();

        // Select a random scripture from the list
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (true)
        {
            Console.WriteLine("Current Scripture:");
            scripture.Display();

            Console.WriteLine();
            Console.WriteLine("Press enter to try this scripture, type 'next' to switch to a different one, or type 'quit' to exit:");

            // Get user input
            string input = Console.ReadLine();

            if (input == "")
            {
                // Try to memorize the current scripture
                MemorizeScripture(scripture);
            }
            else if (input.ToLower() == "next")
            {
                // Select a different scripture

                // Create a list of the other available scriptures
                List<Scripture> otherScriptures = new List<Scripture>();
                foreach (Scripture otherScripture in scriptures)
                {
                    if (otherScripture != scripture)
                    {
                        // Add this scripture to the list of available scriptures if it is
                        // not the currently selected one
                        otherScriptures.Add(otherScripture);
                    }
                }

                // In case the otherScriptures list is empty somehow
                if (otherScriptures.Count == 0)
                {
                    // Select a random scripture that may be the current one
                    scripture = scriptures[random.Next(scriptures.Count)];
                }
                else
                {
                    // Select a new scripture 
                    scripture = otherScriptures[random.Next(otherScriptures.Count)];
                }
            }
            else if (input.ToLower() == "quit")
            {
                // Exit the loop
                break;
            }
        }
    }
}
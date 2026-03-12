using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("Helaman 5:12",
            "And now, my sons, remember, remember that it is upon the rock of our Redeemer, who is Christ, the Son of God, that ye must build your foundation; that when the devil shall send forth his mighty winds, yea, his shafts in the whirlwind, yea, when all his hail and his mighty storm shall beat upon you, it shall have no power over you to drag you down to the gulf of misery and endless wo, because of the rock upon which ye are built, which is a sure foundation, a foundation whereon if men build they cannot fall."
            );

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

            if (input.ToLower() == "")
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
    }
}
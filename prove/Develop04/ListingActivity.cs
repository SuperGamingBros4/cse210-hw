using System;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>([
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    ]);
    private List<string> _availablePrompts = new List<string>();
    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
    )
    {
        // Set the available prompts to a reset state
        ResetAvailablePrompts();
    }

    public void Start()
    {
        // Display the start message
        ShowStartMessage();

        // Get a random prompt
        string prompt = GetPrompt();

        // Display the prompt interface before starting
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($" --- {prompt} --- ");

        // Prepare the user to list responses to the prompt
        Console.Write("You may begin in: ");

        // Pause for 5 seconds
        PauseWithCountdown(5);

        // Count the amount of listed items
        int count = 0;

        // Start the timer
        StartTimer();

        // Keep running until the activity is over
        while (!DurationElapsed())
        {
            // Place a '>' to signal that it is taking input
            Console.Write("> ");

            // Wait for the user to press enter
            string input = Console.ReadLine();

            if (!input.IsWhiteSpace()){
                // Increment the amount of listed items
                count++;
            }
        }

        // Display how many items the user listed
        Console.WriteLine($"You listed {count} items!");

        // Display the finish message
        Finish();
    }
    private void ResetAvailablePrompts()
    {
        // Clear the available prompts before adding prompts
        _availablePrompts.Clear();
        
        // Copy _prompts into _availablePrompts
        foreach (string prompt in _prompts)
        {
            _availablePrompts.Add(prompt);
        }
    }
    private string GetPrompt()
    {
        Random random = new Random();

        // Reset the available prompts if it is empty
        if (_availablePrompts.Count == 0)
            ResetAvailablePrompts();

        // Get a random index into the available prompts
        int index = random.Next(_availablePrompts.Count);

        // Get the prompt at index from the available prompts
        string prompt = _availablePrompts[index];

        // Remove the prompt from the available prompts
        _availablePrompts.RemoveAt(index);

        // Return the prompt
        return prompt;
    }
}
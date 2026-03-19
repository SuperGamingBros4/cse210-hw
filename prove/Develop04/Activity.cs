using System;

public class Activity
{
    private string _title = "";
    private int _duration = 0;
    private DateTime _endTime = DateTime.Now;
    private string _description = "";

    public Activity(string title, string description)
    {
        _title = title;
        _description = description;
    }

    protected void ShowStartMessage()
    {
        // Display the welcome message
        Console.Write("Welcome to the ");
        Console.WriteLine(_title);

        Console.WriteLine();

        // Display the description
        Console.WriteLine(_description);

        Console.WriteLine();

        // Prompt for the duration
        int duration = PromptDuration();

        // Set the duration
        SetDuration(duration);
    }
    private static int PromptDuration()
    {
        // Show the duration prompt
        Console.Write("How long, in seconds, would you like for your session? ");

        // Get input from the user
        string input = Console.ReadLine();

        // Return the input as an integer
        return int.Parse(input);
    }
    private void SetDuration(int duration)
    {
        // Set the duration in seconds

        // Make sure that the duration is above 0 seconds
        if (duration > 0)
        {
            _duration = duration;

            // Set the end time to now + duration
            _endTime = DateTime.Now.AddSeconds(duration);
        }
    }
    public bool DurationElapsed()
    {
        // Return true if the current time is past the end time
        return DateTime.Now > _endTime;
    }
    protected void Finish()
    {
        Console.WriteLine();

        // Display a "well done" message
        Console.WriteLine("Well done!!");

        // Wait for 5 seconds with a spinner
        PauseWithSpinner(5);

        Console.WriteLine();

        // Display a "you completed X seconds of the (activity)" message
        Console.WriteLine($"You have completed another {_duration} of the {_title}.");

        // Pause with a spinner for another 5 seconds
        PauseWithSpinner(5);
    }
    public static void PauseWithSpinner(int duration)
    {
        // A list of bars to cycle through to create the spinner
        string[] bars = ["|", "/", "—", "\\"];
    
        // Set the end time to now + duration
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        // Create a persistent index for displaying the spinner rotation
        int i = 0;

        // Continue until the current time is past the end time
        while (DateTime.Now <= endTime)
        {
            // Display the current spinner rotation
            Console.Write(bars[i]);

            // Pause for a moment
            Thread.Sleep(500);

            // Increment i, making sure that it wraps around
            i++;
            if (i >= bars.Length)
            {
                i = 0;
            }

            // Replace the spinner character with a space and move back a character
            Console.Write("\b \b");
        }
    }
    public static void PauseWithCountdown(int duration)
    {
        // Count down from the duration to the end
        for (int i = duration; i > 0; i--)
        {
            // Convert the number in the countdown to a string
            string countdown = i.ToString();

            // Display the number in the countdown
            Console.Write(countdown);

            // Wait for a second
            Thread.Sleep(1000);

            // Remove each character in the displayed countdown
            for (int j = 0; j < countdown.Length; j++)
            {
                // Overwrite the previous character with a space and go back one character
                Console.Write("\b \b");
            }
        }
    }
}
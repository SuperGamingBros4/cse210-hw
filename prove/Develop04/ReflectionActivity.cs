using System;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>([
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    ]);
    private List<string> _questions = new List<string>([
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    ]);

    public ReflectionActivity() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
    )
    {
        
    }

    public void Start()
    {
        // Display the start message
        ShowStartMessage();

        // Get a random prompt
        string prompt = GetPrompt();

        // Display the prompt interface before starting
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {prompt} --- ");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue");

        // Wait until the user to press enter
        Console.ReadLine();

        // Prepare the user to ponder on the questions
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience");
        Console.Write("You may begin in: ");

        // Pause for 5 seconds
        PauseWithCountdown(5);

        // Clear the console before showing the questions
        Console.Clear();

        // Start the timer
        StartTimer();

        // Keep running until the activity is over
        while (!DurationElapsed())
        {
            // Get a random question
            string question = GetQuestion();

            // Display the question to the user
            Console.Write($"> {question} ");

            // Pause for 20 seconds
            PauseWithSpinner(20);
        }

        // Display the finish message
        Finish();
    }
    public string GetPrompt()
    {
        Random random = new Random();

        return _prompts[random.Next(_prompts.Count)];
    }
    public string GetQuestion()
    {
        Random random = new Random();

        return _questions[random.Next(_questions.Count)];
    }
}
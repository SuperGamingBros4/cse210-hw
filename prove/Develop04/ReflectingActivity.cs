using System;

public class ReflectingActivity : Activity
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
    private List<string> _availablePrompts = new List<string>();
    private List<string> _availableQuestions = new List<string>();

    public ReflectingActivity() : base(
        "Reflecting Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
    )
    {
        // Set the available prompts to a reset state
        ResetAvailablePrompts();
        // Set the available questions to a reset state
        ResetAvailableQuestions();
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
    public string GetPrompt()
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
    private void ResetAvailableQuestions()
    {
        // Clear the available questions before adding questions
        _availableQuestions.Clear();
        
        // Copy _questions into _availableQuestions
        foreach (string question in _questions)
        {
            _availableQuestions.Add(question);
        }
    }
    public string GetQuestion()
    {
        Random random = new Random();

        // Reset the available questions if it is empty
        if (_availableQuestions.Count == 0)
            ResetAvailableQuestions();

        // Get a random index into the available questions
        int index = random.Next(_availableQuestions.Count);

        // Get the question at index from the available questions
        string question = _availableQuestions[index];

        // Remove the prompt from the available prompts
        _availableQuestions.RemoveAt(index);

        // Return the question
        return question;
    }
}
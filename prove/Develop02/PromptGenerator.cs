using System.Collections.Generic;

public class PromptGenerator
{
    Random _randomGenerator = new Random();
    List<string> _prompts = new List<string>();

    public PromptGenerator()
    {
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
        _prompts.Add("What didn't go well today?");
        _prompts.Add("What could I have improved to make today better?");
        _prompts.Add("Did I learn anything new?");
        _prompts.Add("How can I invite more to come unto Christ?");
        _prompts.Add("How can I show more Christ-like love?");
    }

    public string GetNewPrompt()
    {
        int index = _randomGenerator.Next(0, _prompts.Count);
        return _prompts[index];
    }
}
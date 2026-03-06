using System;

public class Entry
{
    public string _date = "";
    public string _prompt = "";
    public string _response = "";

    public void PromptUser(PromptGenerator generator)
    {
        // Get a prompt for the user
        _prompt = generator.GetNewPrompt();

        // Display the prompt to the user
        Console.WriteLine(_prompt);
        Console.Write("> ");

        // Read the user's response
        _response = Console.ReadLine();

        // Write the date into the entry
        _date = DateTime.Now.ToShortDateString();
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine($"> {_response}");
        Console.WriteLine();
    }

    public void SaveToStream(StreamWriter writer)
    {
        // Replace all single, double quotes with double, double quotes
        // " -> ""
        string cleaned_response = _response.Replace("\"", "\"\"");
        string cleaned_date = _date.Replace("\"", "\"\"");
        string cleaned_prompt = _prompt.Replace("\"", "\"\"");

        writer.WriteLine($"\"{cleaned_date}\",\"{cleaned_prompt}\",\"{cleaned_response}\"");
    }
}
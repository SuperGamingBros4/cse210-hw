using System.Collections.Generic;
using System.IO;

public class Journal
{
    List<Entry> _entries = new List<Entry>();
    PromptGenerator _promptGenerator = new PromptGenerator();

    public void AddEntry()
    {
        Entry newEntry = new Entry();
        newEntry.PromptUser(_promptGenerator);

        _entries.Add(newEntry);
    }

    public void Display()
    {
        // Call the display method on each entry
        int i = _entries.Count;
        foreach (Entry entry in _entries)
        {
            Console.Write($"{i--}. ");
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            // Header line
            writer.WriteLine("\"Date\",\"Prompt\",\"Response\"");

            foreach (Entry entry in _entries)
            {
                entry.SaveToStream(writer);
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        List<List<string>> lines;
        try
        {
            lines = CSVReader.ReadAllLines(filename);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        // Clear the current entries in the journal
        _entries.Clear();

        // Parse the file, skipping the header line, and create the entries
        foreach (List<string> values in lines.Skip(1))
        {
            Entry newEntry = new Entry();
            newEntry._date = values[0];
            newEntry._prompt = values[1];
            newEntry._response = values[2];

            _entries.Add(newEntry);
        }
    }

    public void EditEntry()
    {
        Console.Write("Which entry do you want to edit (bottom to top)? ");
        
        Entry entry;
        try
        {
            int backIndex;
            backIndex = int.Parse(Console.ReadLine());

            if (backIndex < 1 || backIndex > _entries.Count)
            {
                Console.WriteLine("That isn't a valid journal entry.");
                return;
            }

            int index = _entries.Count-backIndex;
            entry = _entries[_entries.Count-backIndex];
        }
        catch (FormatException)
        {
            Console.WriteLine("That isn't a number.");
            return;
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("That isn't a valid journal entry.");
            return;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        entry.Display();
        Console.Write("Edit what (date, prompt, response or delete; \"cancel\" to cancel)? ");
        string choice = Console.ReadLine();

        switch (choice.ToLower())
        {
            case "date":
                Console.Write("Enter new date (~ to cancel, today for today): ");
                string date = Console.ReadLine();
                if (date == "~")
                {
                    break;
                }
                else if (date.ToLower() == "today")
                {
                    date = DateTime.Now.ToShortDateString();
                }
                entry._date = date;
                break;
            case "prompt":
                Console.Write("Enter new prompt (~ to cancel): ");
                string prompt = Console.ReadLine();
                if (prompt == "~")
                {
                    break;
                }
                entry._prompt = prompt;
                break;
            case "response":
            case "":
                Console.Write("Enter new response (~ to cancel): ");
                string response = Console.ReadLine();
                if (response == "~")
                {
                    break;
                }
                entry._response = response;
                break;
            case "delete":
                _entries.Remove(entry);
                break;
            default:
                break;
        }
    }
}
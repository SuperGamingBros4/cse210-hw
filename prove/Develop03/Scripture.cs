using System;
using System.Collections.Generic;

public class Scripture
{
    Reference _reference;
    List<Word> _words;

    public Scripture(Reference reference, string words)
    {
        _reference = reference;
        _words = WordsFromString(words);
    }
    public Scripture(string referenceString, string words)
    {
        _reference = new Reference(referenceString, out bool success);

        if (!success)
        {
            Console.WriteLine($"Failed to create new Scripture: Malformed reference '{referenceString}'");
            return;
        }

        _words = WordsFromString(words);
    }

    static private List<Word> WordsFromString(string content)
    {
        List<Word> words = new List<Word>();

        foreach(string wordContent in content.Split(' '))
        {
            Word word = new Word(wordContent);
            words.Add(word);
        }

        return words;
    }
    public void Display()
    {
        // Display the scripture as "(reference): (body)"
        Console.Write($"{_reference}");
        foreach (Word word in _words)
        {
            // Place a space followed by the word into the console
            Console.Write(' ');
            Console.Write(word);
        }
        Console.WriteLine();
    }
    private List<Word> GetVisibleWords()
    {
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (word.IsVisible())
            {
                visibleWords.Add(word);
            }
        }

        return visibleWords;
    }
    public bool IsFullyHidden()
    {
        // Checks if the count is equal to zero
        List<Word> visibleWords = GetVisibleWords();
        return visibleWords.Count == 0;
    }
    public void HideRandomWords(int count)
    {
        // Create a list of visible words to avoid trying to hide already hidden words
        List<Word> visibleWords = GetVisibleWords();

        Random random = new Random();
        while (count-- > 0 && visibleWords.Count > 0)
        {
            Word word = visibleWords[random.Next(visibleWords.Count)];
            word.SetVisible(false);

            // Remove the word from the list so that it isn't selected again on the
            // next iteration
            visibleWords.Remove(word);
        }
    }
}
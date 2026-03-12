using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        // Single verse reference
        SetBook(book);
        SetChapter(chapter);
        SetVerse(verse);
    }
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        // Range of verses reference
        SetBook(book);
        SetChapter(chapter);
        SetVerseRange(startVerse, endVerse);
    }
    public Reference(string referenceString, out bool success)
    {
        // Deserialize the reference string into a Reference object
        success = Deserialize(referenceString);
    }

    private bool Deserialize(string referenceString)
    {
        // reads a reference from a string and returns true on success and false on fail

        string book = "";
        int chapter = 0;
        int verse = 0;
        int endVerse = 0;

        // Split the scripture up by the ':'
        string[] sides = referenceString.Split(':', StringSplitOptions.TrimEntries);
        if (sides.Length != 2)
        {
            Console.WriteLine($"Error: Malformed scripture reference '{referenceString}': missing or extra colons");
            return false;
        }

        string lhs = sides[0];
        for (int i = lhs.Length - 1; i >= 0; i--)
        {
            // Search backwards through the left side until reaching a space.
            // We do this because some books have spaces in them, so we cannot split it

            if (lhs[i] == ' ')
            {
                try
                {
                    // This last part should be the chapter
                    string chapterString = lhs.Substring(i);
                    chapter = int.Parse(chapterString);
                }
                catch (Exception e)
                {
                    // Catch any problems while reading the chapter from the reference string
                    Console.WriteLine($"Error: Malformed scripture reference '{referenceString}'");
                    Console.WriteLine(e.Message);
                    return false;
                }

                // Everything before the chapter (minus the space) should be the book
                book = lhs.Substring(0, i);

                break;
            }
            else if (i == 0)
            {
                Console.WriteLine($"Error: malformed scripture reference '{referenceString}': malformed book and chapter");
                return false;
            }
        }

        string rhs = sides[1];
        string[] rhsSplit = rhs.Split('-', StringSplitOptions.TrimEntries);

        try
        {
            if (rhsSplit.Length == 1)
            {
                // This should be just one verse
                verse = int.Parse(rhsSplit[0]);
                endVerse = int.Parse(rhsSplit[0]);
            }
            else if (rhsSplit.Length == 2)
            {
                // This should be two verses
                verse = int.Parse(rhsSplit[0]);
                endVerse = int.Parse(rhsSplit[1]);
            }
            else
            {
                Console.WriteLine($"Error: Malformed scripture reference '{referenceString}': malformed verses");
                return false;
            }
        }
        catch (Exception e)
        {
            // Catch any problems while reading the verse from the reference string 
            Console.WriteLine($"Error: Malformed scripture reference '{referenceString}'");
            Console.WriteLine(e.Message);
            return false;
        }

        SetBook(book);
        SetChapter(chapter);
        SetVerseRange(verse, endVerse);

        return true;
    }
    public string GetDisplay()
    {
        // Format the reference like: "(book) (chapter):(verse)" or "(book) (chapter):(startVerse)-(endVerse)"
        // e.g. "Jacob 4:5" or "2 Nephi 17:1-5"

        if (_verse == _endVerse)
        {
            // Single verse case
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            // Range of verses case
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
    public override string ToString()
    {
        return GetDisplay();
    }

    public string GetBook()
    {
        return _book;
    }
    public void SetBook(string book)
    {
        _book = book;
    }
    public int GetChapter()
    {
        return _chapter;
    }
    public void SetChapter(int chapter)
    {
        if (chapter < 1)
        {
            Console.WriteLine("Error: chapter is less than 1");
            return;
        }
        _chapter = chapter;
    }
    public int GetVerse()
    {
        return _verse;
    }
    public void SetVerse(int verse)
    {
        // Sets the reference to a single verse
        if (verse < 1)
        {
            Console.WriteLine("Error: verse is less than 1");
            return;
        }
        _verse = verse;
        _endVerse = verse;
    }
    public void SetVerseRange(int startVerse, int endVerse)
    {
        if (startVerse < 1)
        {
            Console.WriteLine("Error: startVerse is less than 1");
            return;
        }
        else if (endVerse < 1)
        {
            Console.WriteLine("Error: endVerse is less than 1");
            return;
        }
        // Sets the reference to a range of verses
        _verse = startVerse;
        _endVerse = endVerse;
    }
    public int GetEndVerse()
    {
        return _endVerse;
    }
}
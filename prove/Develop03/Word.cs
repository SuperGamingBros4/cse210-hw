public class Word
{
    private string _content;
    private bool _visibility;

    public Word(string word)
    {
        _content = word;
        _visibility = true;
    }

    public string GetDisplay()
    {
        if (_visibility)
        {
            // Return the word content if it is visible
            return _content;
        }
        else
        {
            // Return a string of '_' the same length as the content if it is
            // invisible
            return new string('_', _content.Length);
        }
    }
    public override string ToString()
    {
        // Return the displayed word so the class can be printed directly like:
        // `Console.WriteLine(Word)` without having to call `Word.GetDisplay()`
        return GetDisplay();
    }

    public string GetContent()
    {
        return _content;
    }
    public void SetContent(string content)
    {
        _content = content;
    }
    public bool GetVisibility()
    {
        return _visibility;
    }
    public void SetVisibility(bool visibility)
    {
        _visibility = visibility;
    }
}
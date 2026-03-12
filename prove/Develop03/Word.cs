public class Word
{
    private string _content;
    private bool _visible;

    public Word(string word)
    {
        _content = word;
        SetVisible(true);
    }

    public string GetDisplay()
    {
        if (IsVisible())
        {
            // If it is visible, return the word content
            return GetRawContent();
        }
        else
        {
            // If it is invisible, return a string of '_' the same length as the
            // content
            return new string('_', _content.Length);
        }
    }
    public override string ToString()
    {
        // Return the displayed word so the class can be printed directly like:
        // `Console.WriteLine(Word)` without having to call `Word.GetDisplay()`
        return GetDisplay();
    }

    public string GetRawContent()
    {
        return _content;
    }
    public bool IsVisible()
    {
        return _visible;
    }
    public void SetVisible(bool visible)
    {
        _visible = visible;
    }
}
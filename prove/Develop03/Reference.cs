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
        _chapter = chapter;
    }
    public int GetVerse()
    {
        return _verse;
    }
    public void SetVerse(int verse)
    {
        // Sets the reference to a single verse
        _verse = verse;
        _endVerse = verse;
    }
    public void SetVerseRange(int startVerse, int endVerse)
    {
        // Sets the reference to a range of verses
        _verse = startVerse;
        _endVerse = endVerse;
    }
    public int GetEndVerse()
    {
        return _endVerse;
    }
}
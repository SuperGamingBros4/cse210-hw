public class Video
{
    public string _title;
    public string _author;
    public double _seconds;
    public List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, double seconds)
    {
        _title = title;
        _author = author;
        _seconds = seconds;
    }

    public int GetCommentsCount()
    {
        return _comments.Count;
    }
}
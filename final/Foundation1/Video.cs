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
    public void AddComment(string author, string text)
    {
        // Create a comment from the provided information
        Comment comment = new Comment(author, text);

        // Add the comment to the video's comments
        _comments.Add(comment);
    }
    public void Display()
    {
        // Display the video's title, author, length, and number of comments
        Console.WriteLine($"Title: {_title}, author: {_author}, length: {_seconds} seconds, {GetCommentsCount()} comments");
    }
    public void DisplayComments()
    {
        // Display the comments on the video
        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"  {comment._author}: {comment._text}");
        }
    }
}
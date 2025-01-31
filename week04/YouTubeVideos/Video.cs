using System.Security.Cryptography.X509Certificates;

public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length) // Length entered in seconds
    {
        _title = title;
        _length = length;
        _author = author;
        _comments = new List<Comment>(); 
    }

    public Video(string title, string author, string length) // Length entered in mm:ss, or hh:mm:ss
    {
        _title = title;
        _author = author;
        _comments = new List<Comment>(); 

        string[] lengthParts = length.Split(':');
        if (lengthParts.Length == 3)
        {
            _length = int.Parse(lengthParts[0]) * 3600 + int.Parse(lengthParts[1]) * 60 + int.Parse(lengthParts[2]);
        }
        else if (lengthParts.Length == 2)
        {
            _length = int.Parse(lengthParts[0]) * 60 + int.Parse(lengthParts[1]);
        }
        else
        {
            _length = int.Parse(lengthParts[0]);
        }
        
    }

    public void AddComment(string name, string text) // If given comment components
    {
        _comments.Add(new Comment(name, text));
    }

    public void AddComment(Comment comment) // If comment is made separately
    {
        _comments.Add(comment);
    }

    public int CommentCount()
    {
        return _comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"\n\nTitle: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"\nComments: {CommentCount()}");
        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"{comment.GetDisplayText()}"); 
        }
    }
}
public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = startVerse;
    }
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public Reference(string reference)
    {
        string[] bookParts = reference.Split(' ');
        _book = string.Join(" ", bookParts.Take(bookParts.Length - 1));
        string chapVerse = bookParts.Last();
        string[] chapVerseParts = chapVerse.Split(new char[] { ':', '-' });
        _chapter = int.Parse(chapVerseParts[0]);
        _startVerse = int.Parse(chapVerseParts[1]);
        if (chapVerseParts.Length == 3)
        {
            _endVerse = int.Parse(chapVerseParts[2]);
        }
        else
        {
            _endVerse = _startVerse;
        }
    }
    
    public string GetDisplayText()
    {
        string display = _book + " " + _chapter + ":" + _startVerse;
        if (_endVerse != _startVerse)
        {
            display += "-" + _endVerse;
        }
        return display;
    }
}

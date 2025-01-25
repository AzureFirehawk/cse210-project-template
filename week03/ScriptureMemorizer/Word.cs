public class Word
{
    private string _text;
    private string _hiddenText;
    private bool _isHidden;

    

    public Word(string text)
    {
        _text = text;

        char[] letters = _text.ToCharArray();
        int index = 0;
        foreach (char ch in letters)
        {
            if (ch != ' ' && !char.IsPunctuation(ch) && !char.IsSymbol(ch) && !char.IsDigit(ch))  
            {
                letters[index] = '_';
            }
            index++;
        }
        _hiddenText = new string(letters);

        _isHidden = false;
    }

    public void Hide()
    {
        if (!_isHidden)
        {
            _isHidden = true;
        }
    }

    public void Show()
    {
        if (_isHidden)
        {
            _isHidden = false;
        }
    }  

    public bool IsHidden()
    {   
        return _isHidden;
    }

    public string DisplayText()
    {
        if (_isHidden)
        {
            return _hiddenText;
        }
        else
        {
            return _text;
        }
    }
}

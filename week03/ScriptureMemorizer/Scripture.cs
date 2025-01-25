public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference)
    {
        _reference = reference;
        int i = 0;
        string[] lines = File.ReadAllLines("Scriptures.txt");
        foreach (string line in lines)
        {
            if (line != "")
            {
                string[] parts = line.Split("$");

                string verse = parts[0].Trim();
                string text = parts[1].Trim();
                if (verse == reference.GetDisplayText())
                {
                    string[] words = text.Split(' ');
                    foreach (string word in words)
                    {
                        _words.Add(new Word(word));
                    }
                    i++;
                }
            else 
                {
                    continue;
                }               
            }
        }
        if (i == 0)
        {
            Console.WriteLine("No scripture found for that reference.");
        }
    }

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public string GetDisplayText()
    {
        string display = "";
        foreach (Word word in _words)
        {
            display += word.DisplayText() + " ";
        }
        return display;
    }    

    public void HideWords(int numberToHide)
    {
        int i = 0;
        while (i < numberToHide)  
            if (!IsCompletelyHidden())
            {
                Random random = new Random();
                int index = random.Next(_words.Count);
                if (!_words[index].IsHidden())
                {
                _words[index].Hide();
                i++;
                }
                else
                {
                    continue;
                }
            }
            else
            {
                break;
            }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}

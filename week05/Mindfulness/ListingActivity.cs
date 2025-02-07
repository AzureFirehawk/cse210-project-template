public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "What are some of your favorite things to do?"
    };
    private List<string> _usedPrompts = new List<string>();

    public ListingActivity() : base() 
    {
        _name = "Listing Activity";
        _description = $"This activity will help you reflect on the good things in your life that may be easy to miss.\nReminding ourselves of the positive aspects of life is a great way to lift our mentals state.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        GetListFromUser();
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        if (_usedPrompts.Count < _prompts.Count)
        {
            Random random = new Random();
            int index = random.Next(_prompts.Count);
            string prompt = _prompts[index];
            if (!_usedPrompts.Contains(prompt))
            {
                _usedPrompts.Add(prompt);
                return prompt;
            }
            else
            {
                return GetRandomPrompt();
            }
        }
        else if (_usedPrompts.Count >= _prompts.Count)
        {
            _usedPrompts.Clear();
            return GetRandomPrompt();
        }
        return "";
    }

    public void GetListFromUser()
    {
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($" --- {GetRandomPrompt()} --- ");
        Console.Write($"You may begin in: "); ShowCountdown(5);
        _count = 0;
        List<string> list = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        Console.WriteLine();
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            _count++;
            list.Add(input);  
        }
        Console.WriteLine($"You listed {_count} items.");

    }
}
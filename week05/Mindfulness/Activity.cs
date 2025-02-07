using System.ComponentModel.DataAnnotations;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected int _totalDuration;

    public Activity(){
        _totalDuration = 0;
        string[] lines = File.ReadAllLines("Times.txt");
        foreach (string line in lines)
        {
            if (line != "")
            {
                string[] parts = line.Split(":");
                if (parts[0].Trim() == _name)
                {
                    _totalDuration += int.Parse(parts[1].Trim());
                }
            }
        }
    }

    public virtual void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}!\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(5);
    }

    public virtual void DisplayEndingMessage()
    {
        Console.WriteLine($"\nWell done!");
        ShowSpinner(5);
        if (_totalDuration>0)
        {
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}, bringing your total to {_totalDuration} seconds.");
        ShowSpinner(5);
        }
        else
        {
        Console.WriteLine($"\nYou have completed {_duration} seconds of the {_name}.");
        ShowSpinner(5);
        }
        using (StreamWriter file = File.AppendText("Times.txt"))
        {
            file.WriteLine($"{_name}:{_duration}");
        }
        _totalDuration += _duration;
    }

    public virtual void ShowSpinner(int duration)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);  
        List<string> spinner = new List<string> {"|", "/", "—", "\\"};
        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = spinner[i];
            Console.Write(s);
            Thread.Sleep(400);
            Console.Write("\b \b");
            i++;
            if (i >= spinner.Count)
            {
                i = 0;
            }
        }
    }

    public virtual void ShowCountdown(int duration)
    {
        for (int i = duration; i > 0; i-- )
        {
            Console.Write($"{i}"); 
            Thread.Sleep(1000);             
            Console.Write("\b \b");
        }
    }
}
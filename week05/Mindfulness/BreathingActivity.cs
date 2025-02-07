public class BreathingActivity : Activity
{
    public BreathingActivity() : base()
    {
        _name = "Breathing Activity";
        _description = "This is a simple breathing exercise to help you relax and clear your mind.";

    }
    
    public void Run()
    {
        DisplayStartingMessage();
        int remainder = _duration % 10;
        int breathCount = (_duration - remainder) / 10;
        for (int i = 0; i < breathCount; i++)
        {
            if (remainder > 0)
            {
                Console.Write("\nBreath in...");
                ShowSpinner(remainder/2);
                Console.Write("\nBreath out...");
                ShowSpinner(remainder/2);
                Console.WriteLine();
            }
            Console.Write("\nBreathe in...");
            ShowCountdown(4);
            Console.Write("\nBreathe out...");
            ShowCountdown(6);
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }
    
}
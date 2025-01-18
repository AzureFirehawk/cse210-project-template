public class PromptGenerate
{
    public static List<string> _prompts = new List<string> {
        "What was the best part of my day?",
        "If I had one thing I could do over today, what would it be?",
        "How did I see the hand of the Lord in my life today?",
        "What could have made today even better?",
        "What is one thing I accomplished today?",
        "What was an interesting interaction I had today?",
        "What made me laugh today?",
        "What was the most challenging thing I faced today?"
    };

    public string GetPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you did something that made you proud.",
        "Think of a time when you comforted a friend or loved one."
    };
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "How can you keep this experience in mind in the future?"
    };
    private List<string> _usedPrompts = new List<string>();
    private List<string> _usedQuestions = new List<string>();

    public ReflectionActivity() : base()
    {
        _name = "Reflection Activity";
        _description = "Reflect on times in your life when you have shown strength and resilience.\nThis will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        DisplayQuestions();
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

    public string GetRandomQuestion()
    {
        if (_usedQuestions.Count < _questions.Count)
        {
            Random random = new Random();
            int index = random.Next(_questions.Count);
            string question = _questions[index];
            if (!_usedQuestions.Contains(question))
            {
                _usedQuestions.Add(question);
                return question;
            }
            else
            {
                return GetRandomQuestion();
            }
        }
        else if (_usedQuestions.Count >= _questions.Count)
        {
            _usedQuestions.Clear();
            return GetRandomQuestion();
        }
        return "";
    }
    
    public void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($" --- {GetRandomPrompt()} --- ");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.Clear();
    }

    public void DisplayQuestions()
    {
        int questionCount = (_duration - (_duration % 10)) / 10;
        for (int i = 0; i < questionCount; i++)
        {
            Console.Write($"> {GetRandomQuestion()}");
            ShowSpinner(_duration/questionCount);
            Console.WriteLine();
        }
        _usedQuestions.Clear();
    }

}
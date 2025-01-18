using System.IO;

public class Journal
{
    // Initialize variables
    public List<Entry> _entries = new List<Entry>();
    public List<string> _usedPrompts = new List<string>();

    public void AddEntry()
    {
        string prompt = new PromptGenerate().GetPrompt();
        while (true)
        {
            if (_usedPrompts.Contains(prompt))
            {
                if (_usedPrompts.Count >= PromptGenerate._prompts.Count)
                {
                    Console.WriteLine("You have reached the maximum number of prompts.");
                    break;
                }
                else
                {
                    prompt = new PromptGenerate().GetPrompt();  
                } 
            }
            else if (!_usedPrompts.Contains(prompt))
            {
                Entry newEntry = new Entry();
                DateTime today = DateTime.Today;
                newEntry._date = today.ToString("d");
                newEntry._prompt = prompt;
                Console.Write(newEntry._prompt + " ");
                newEntry._answer = Console.ReadLine();
                _entries.Add(newEntry);
                _usedPrompts.Add(newEntry._prompt);
                if (_usedPrompts.Count >= PromptGenerate._prompts.Count)
                {
                    Console.WriteLine("You have reached the maximum number of prompts.");
                    break;
                }
                break;
            }
        }
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public string SaveToFile(string file)
    {
        Console.WriteLine("\nSaving to file...");
        string fileName = file;
        using (StreamWriter outputFile = File.AppendText($"..\\..\\..\\{fileName}"))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"Date: {entry._date} — Prompt: {entry._prompt} — {entry._answer}");
            }
        }
        return fileName;
    }

    public string LoadFromFile(string file, string dateRequest)
    {
        string fileName = file;
        int i = 0;
        string[] lines = File.ReadAllLines($"..\\..\\..\\{fileName}");
        foreach (string line in lines)
        {
            string[] parts = line.Split("—");

            string date = parts[0].Trim();
            string prompt = parts[1].Trim();
            string answer = parts[2].Trim();
            if (date == dateRequest || dateRequest.ToLower().TrimEnd() == "date: all")
            {
                Console.WriteLine($"{date} - {prompt}\n{answer}\n");
                i++;
            }
        }
        if (i == 0)
        {
            Console.WriteLine("No entries found for that date.");
        }
        return fileName;
    }
}
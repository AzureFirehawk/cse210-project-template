public class GoalManager
{
    private List<Goal> _goals; // list of goals
    private int _scoreTotal;
    private int _scoreRemaining;
    private int _level;


    public GoalManager() 
    {
        _scoreTotal = 0;
        _level = 1;
        _goals = new List<Goal>();
    }

    public void Start()
    {
        while (true)
        {
            _level = CalculateLevel();
            _scoreRemaining = CalculateScoreRemaining();
            DisplayPlayerInfo();
            Console.Write("Menu Options:\n  1. Create New Goal\n  2. List Goals\n  3. Save Goals\n  4. Load Goals\n  5. Record Event\n  6. Quit\nSelect a choice from the menu: ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                Console.Write("What is the file name you are saving to? ");
                string file = Console.ReadLine();
                SaveGoals(file);
            }
            else if (choice == "4")
            {
                Console.Write("What is the file name you are loading from? ");
                string file = Console.ReadLine();
                LoadGoals(file);
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "6")
            {
                break;
            }
            else
            {
                Console.WriteLine("That is not a valid input...");
            }
        }
    }

    public void DisplayPlayerInfo()
    {

        Console.WriteLine($"\nLevel: {_level}\nScore this Level: {_scoreRemaining}\nPoints to Next Level: {PointsToNextLevel()}\n");
    }

    public void ListGoalNames()
    {
        int i = 1;
        foreach (Goal goal in _goals)
        {
            string[] details = goal.GetStringRepresentation().Split("š");
            Console.WriteLine($"  {i}. {details[1].Trim()}");
            i++;
        }
    }

    public void ListGoalDetails()
    {
        int i = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.GetDetailsString()}");
            i++;
        }
    }

    public void CreateGoal()
    {
        Console.Write("The types of Goals are:\n  1. Simple Goal\n  2. Eternal Goal\n  3. Checklist Goal\nWhich type of goal would you like to create? ");
        string input = Console.ReadLine();
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a brief description of this goal? ");
        string description = Console.ReadLine();
        Console.Write("How difficult is this goal to you?\n  1. Easy\n  2. Average\n  3. Hard\nWhat is your rating? ");
        string difficulty = Console.ReadLine();
        int points = 0;
        if (difficulty == "1")
        {
            points = 8;
        }
        else if (difficulty == "2")
        {
            points = 10;
        }
        else if (difficulty == "3")
        {
            points = 12;
        }
        if (input == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (input == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (input == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            int bonus = points*target*target;
            _goals.Add(new ChecklistGoal(name, description, points, bonus, target));
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Your goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;
        _goals[goalIndex].RecordEvent();
        _scoreTotal += GoalPoints(_goals[goalIndex]);
        Console.WriteLine($"You now have {_scoreRemaining} points.");
    }

    private void SaveGoals(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_scoreRemaining);
            outputFile.WriteLine(_level);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    private void LoadGoals(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        _scoreRemaining = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);
        foreach (string line in lines)
        {
            if (line != "")
            {
                string[] parts = line.Split("š");
                string type = parts[0].Trim();
                if (type == "SimpleGoal")
                {
                    _goals.Add(new SimpleGoal(parts[1].Trim(), parts[2].Trim(), int.Parse(parts[3].Trim()), bool.Parse(parts[4].Trim())));
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(parts[1].Trim(), parts[2].Trim(), int.Parse(parts[3].Trim())));
                }
                else if (type == "ChecklistGoal")
                {
                    _goals.Add(new ChecklistGoal(parts[1].Trim(), parts[2].Trim(), int.Parse(parts[3].Trim()), int.Parse(parts[4].Trim()), int.Parse(parts[5].Trim()), int.Parse(parts[6].Trim())));
                }
            }
        }
    }

    public int GoalPoints(Goal goal)
    {
        int points = 0;
        string[] details = goal.GetStringRepresentation().Split("š");
        
        string goalType = details[0].Trim();

        if (goalType == "SimpleGoal" || goalType == "EternalGoal")
        {
            return int.Parse(details[3].Trim());
        }
        else if (goalType == "ChecklistGoal")
        {
            points = int.Parse(details[3].Trim());
            if (int.Parse(details[6]) >= int.Parse(details[5]))
            {
                points += int.Parse(details[4]);
            }
        }
        return points;
    }

    private int CalculateLevel()
    {
        int level = 1;
        int score = _scoreTotal;
        while (true)
        {
            string scoreNeededString = Convert.ToString(Math.Round(Math.Pow(4 * _level, 3) / 5));
            int scoreNeeded = int.Parse(scoreNeededString);
            if (score >= scoreNeeded)
            {
                level += 1;
                score -= scoreNeeded;
            }
            else
            {
                break;
            }
        }
        return level;
    }

    private int CalculateScoreRemaining()
    {
        int score = _scoreTotal;
        string scoreNeededString = Convert.ToString(Math.Round(Math.Pow(4 * (_level-1), 3) / 5));
        int scoreNeeded = int.Parse(scoreNeededString);
        int scoreRemaining = score-scoreNeeded;
        if (scoreRemaining < 0)
        {
            scoreRemaining = 0;
        }
        return scoreRemaining;
    }

    private int PointsToNextLevel()
    {
        int score = _scoreTotal;
        string scoreNeededString = Convert.ToString(Math.Round(Math.Pow(4 * _level, 3) / 5));
        int scoreNeeded = int.Parse(scoreNeededString);
        return scoreNeeded - score;
    }
}


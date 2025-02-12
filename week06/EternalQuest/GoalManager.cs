public class GoalManager
{
    private List<Goal> _goals; // list of goals
    private int _score;

    public GoalManager() 
    {
        _score = 0;
        _goals = new List<Goal>();
    }

    public void Start()
    {
        while (true)
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points:\n");
    }

    public void ListGoalNames()
    {
        foreach (Goal goal in _goals)
        {
            string[] details = goal.GetDetailsString().Split("š");
            Console.WriteLine(details[1].Trim());
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
        Console.Write("The types of Goals are:\n  1. Simple Goal\n  2. Eternal Goal\n  3.Checklist Goal\nWhich type of goal would you like to create? ");
        string input = Console.ReadLine();
        
    }

    public int GoalPoints(Goal goal)
    {
        int points = 0;
        string[] details = goal.GetDetailsString().Split("š");
        
        string goalType = details[0].Trim();

        if (goalType == "SimpleGoal" || goalType == "EternalGoal")
        {
            return int.Parse(details[3].Trim());
        }
        else if (goalType == "ChecklistGoal")
        {
            points = int.Parse(details[3].Trim());
            if (int.Parse(details[5]) >= int.Parse(details[6]))
            {
                points += int.Parse(details[4]);
            }
        }
        return points;
    }
}
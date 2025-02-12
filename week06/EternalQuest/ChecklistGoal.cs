public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _target;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int bonusPoints, int target) : base(name, description, points)
    {
        _timesCompleted = 0;
        _target = target;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
        if (_timesCompleted >= _target)
        {
            Console.WriteLine($"Congratulations! You have earned {_points+_bonusPoints} points!");
        }
        else
        {
            Console.WriteLine($"Congratulations! You have earned {_points} points!");
        }
    }

    public override bool IsComplete()
    {
        return _timesCompleted >= _target;   
    }

    public override string GetDetailsString()
    {
        return base.GetDetailsString() + $" -- ({_timesCompleted}/{_target})";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal š {_name} š {_description} š {_points} š {_bonusPoints} š {_target} š {_timesCompleted}";
    }
}
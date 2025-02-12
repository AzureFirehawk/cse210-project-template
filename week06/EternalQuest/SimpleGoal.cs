public class SimpleGoal : Goal
{
    private bool _isComplete;
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Congratulations! You have earned {_points} points!");
        _isComplete = true;
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal š {_name} š {_description} š {_points} š {_isComplete}";
    }
}
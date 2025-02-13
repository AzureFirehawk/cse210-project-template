public class SimpleGoal : Goal
{
    private bool _isComplete;
    public SimpleGoal(string name, string description, int points, bool isComplete = false) : base(name, description, points) 
    {
        _isComplete = isComplete;
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
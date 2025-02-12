using System.ComponentModel;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string completeTag = " ";
        if (IsComplete())
        {
            completeTag = "X";
        }
        return $"[{completeTag}]{_name} ({_description})";   
    }

    public abstract string GetStringRepresentation();
}

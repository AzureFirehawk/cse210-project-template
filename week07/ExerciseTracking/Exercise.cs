public abstract class Exercise
{
    protected string _name;
    protected string _date;
    protected int _duration;

    public Exercise(int duration) 
    {
        DateTime date = DateTime.Now;
        _date = date.ToString("dd MMM yyyy");
        _duration = duration;
    }   

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date} {_name} ({_duration} min): Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min/mile";
    }

    public virtual string GetSaveSummary()
    {
        return $"{_date} š {_name} š {_duration} š {GetDistance():F1} š {GetSpeed():F1} š {GetPace():F1}";
    }
}
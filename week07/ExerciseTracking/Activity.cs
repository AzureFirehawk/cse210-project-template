public abstract class Activity
{
    protected string _name;
    protected string _date;
    protected int _duration;

    public Activity(int duration) 
    {
        DateTime date = DateTime.Now;
        _date = date.ToString("dd MMM yyyy");
        _duration = duration;
    }   

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public virtual void GetSummary()
    {
        Console.WriteLine($"{_date} {_name} ({_duration} min): Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min/mile");
    }
}
public class Swimming : Exercise
{
    private int _laps;
    public Swimming(int duration,int laps) : base(duration) 
    {
        _name = "Swimming";
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000.0;
    }

    public override double GetSpeed()
    {
        return Math.Round(GetDistance() / _duration * 60.0, 1);
    }

    public override double GetPace()
    {
        return Math.Round(_duration / GetDistance(), 1);
    }

    public override string GetSaveSummary()
    {
        return $"{_date} š {_name} š {_duration} š {_laps} š {GetDistance():F1} š {GetSpeed():F1} š {GetPace():F1}";
    }
}

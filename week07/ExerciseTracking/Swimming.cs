public class Swimming : Activity
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
}

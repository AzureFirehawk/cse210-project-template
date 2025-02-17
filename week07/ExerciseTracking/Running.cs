public class Running : Activity
{
    private double _distance;

    public Running(int duration, double distance) : base(duration)
    {
        _name = "Running";
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return Math.Round(_distance / _duration * 60.0, 2);
    }

    public override double GetPace()
    {
        return Math.Round(_duration / _distance, 2);
    }
}
public class Bicycles : Activity
{
    private double _speed;

    public Bicycles(int duration, double speed) : base(duration)
    {
        _name = "Bicycles";
        _speed = speed;
    }

    public override double GetDistance()
    {
        return Math.Round(_speed * _duration / 60.0, 1);
    }

    public override double GetSpeed()
    {
        return Math.Round(_speed,1);
    }

    public override double GetPace()
    {
        return Math.Round(60/_speed, 1);
    }
}
public class Fraction
{
    private int _topNumber;
    private int _bottomNumber;

    public Fraction() // Default
    {
        _topNumber = 1;
        _bottomNumber = 1;
    }

    public Fraction(int topNumber) // One variable
    {
        _topNumber = topNumber;
        _bottomNumber = 1;

    }

    public Fraction(int topNumber, int bottomNumber) // Two variable
    {
        _topNumber = topNumber;
        _bottomNumber = bottomNumber;
    }

    public int GetTopNumber()
    {
        return _topNumber;
    }

    public int GetBottomNumber()
    {
        return _bottomNumber;
    }

    public int SetBottomNumber(int bottomNumber)
    {
        _bottomNumber = bottomNumber;
        return _bottomNumber;
    }

    public int SetTopNumber(int topNumber)
    {
        _topNumber = topNumber;
        return _topNumber;
    }

    public string GetFractionString()
    {
        string fraction = $"{_topNumber}/{_bottomNumber}";
        return fraction;
    }

    public double GetDecimalValue()
    {
        double decimalValue = (double)_topNumber / (double)_bottomNumber;
        return decimalValue;
    }
}
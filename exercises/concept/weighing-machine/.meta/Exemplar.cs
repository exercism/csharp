using System;

class WeighingMachine
{
    private int _weight;

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }

    public int Precision { get; }

    public int TareAdjustment { get; set; } = 5;

    public int Weight
    {
        get
        {
            return _weight;
        }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException();
            _weight = value;
        }
    }

    public int DisplayWeight
    {
        get
        {
            return Weight - TareAdjustment;
        }
    }
}
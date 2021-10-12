using System;

class WeighingMachine
{
    private int _weight;

    public WeighingMachine(string precision)
    {
        Precision = precision;
    }

    public string Precision { get; }

    public int TareAdjustment { get; set; } = 5;

    public int Weight
    {
        get
        {
            return Math.Round(_weight, int.Parse(Precision));
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
            return Weight - TareAdjustment
        }
    }
}
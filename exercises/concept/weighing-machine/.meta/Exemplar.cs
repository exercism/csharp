using System;

class WeighingMachine
{
    private double _weight;

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }

    public int Precision { get; }

    public double TareAdjustment { get; set; } = 5.0;

    public double Weight
    {
        get
        {
            return Math.Round(_weight, Precision);
        }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException();
            _weight = value;
        }
    }

    public string DisplayWeight
    {
        get
        {
            return $"{Math.Round(Weight - TareAdjustment, Precision).ToString($"F{Precision}")} kg";
        }
    }
}
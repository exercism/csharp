using System;

class WeighingMachine
{
    private int _weight;

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }

    // Goal: getter-only property initialized in constructor
    public int Precision { get; }

    // Goal: auto-implemented get/set property with initial value
    public int TareAdjustment { get; set; } = 5;

    // Goal: explicit get/set property
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

    // Goal: getter-only property with logic 
    public int DisplayWeight
    {
        get
        {
            return Weight - TareAdjustment;
        }
    }
}
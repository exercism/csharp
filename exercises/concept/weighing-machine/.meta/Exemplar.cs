using System;

enum Unit
{
    Pounds,
    Kilograms
}

class WeighingMachine
{
    private const decimal POUNDS_PER_KILOGRAM = 2.20462m;

    private decimal inputWeight;

    public Unit Unit { get; set; } = Unit.Kilograms;

    public decimal InputWeight
    {
        get
        {
            return inputWeight;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("weight cannot be negative");
            }

            inputWeight = value;
        }
    }

    public decimal DisplayWeight
    {
        get
        {
            return ApplyTareAdjustment(inputWeight);
        }
    }

    public USWeight USDisplayWeight
    {
        get
        {
            return new USWeight(WeightInPounds(DisplayWeight));
        }
    }

    public decimal TareAdjustment { set; private get; }

    private decimal ApplyTareAdjustment(decimal weight)
    {
        return weight - TareAdjustment;
    }

    private decimal WeightInPounds(decimal weight)
    {
        if (Unit == Unit.Kilograms)
        {
            return weight * POUNDS_PER_KILOGRAM;
        }

        return weight;
    }
}

class USWeight
{
    private const decimal OUNCES_PER_POUND = 16m;

    public USWeight(decimal displayWeightInPounds)
    {
        Pounds = (int)displayWeightInPounds;
        Ounces = (int)(OUNCES_PER_POUND * (displayWeightInPounds - (int)displayWeightInPounds));
    }

    public int Pounds { get; }
    public int Ounces { get; }
}

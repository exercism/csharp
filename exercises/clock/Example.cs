public struct Clock
{
    private readonly int hours;
    private readonly int minutes;

    public Clock(int hours, int minutes = 0)
    {
        this.hours = Mod((hours * 60 + minutes) / 60.0, 24);
        this.minutes = Mod(minutes, 60);
    }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(hours, minutes + minutesToAdd);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(hours, minutes - minutesToSubtract);
    }

    public override string ToString()
    {
        return $"{hours:00}:{minutes:00}";
    }

    private static int Mod(double x, double y)
    {
        return (int)((x % y + y) % y);
    }
}
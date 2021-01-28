static class AssemblyLine
{
    private const int ProductionRatePerHourForDefaultSpeed = 221;

    public static double ProductionRatePerHour(int speed)
    {
        return ProductionRatePerHourForSpeed(speed) * SuccessRate(speed);
    }

    private static int ProductionRatePerHourForSpeed(int speed)
    {
        return ProductionRatePerHourForDefaultSpeed * speed;
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return (int)(ProductionRatePerHour(speed) / 60);
    }

    private static double SuccessRate(int speed)
    {
        if (speed == 10)
        {
            return 0.77;
        }

        if (speed == 9)
        {
            return 0.8;
        }

        if (speed >= 5)
        {
            return 0.9;
        }

        return 1;
    }
}

public static class AssemblyLine
{
    private const int ProductionRatePerHourForDefaultSpeed = 221;

    public static double ProductionRatePerHour(int speed) =>
        ProductionRatePerHourForSpeed(speed) * SuccessRate(speed);

    private static int ProductionRatePerHourForSpeed(int speed) =>
        ProductionRatePerHourForDefaultSpeed * speed;

    public static int WorkingItemsPerMinute(int speed) =>
        (int)ProductionRatePerHour(speed) / 60;

    private static double SuccessRate(int speed)
    {
        if (speed == 0)
            return 0.0;

        if (speed >= 9)
            return 0.77;

        if (speed < 5)
            return 1.0;

        return 0.9;
    }
}
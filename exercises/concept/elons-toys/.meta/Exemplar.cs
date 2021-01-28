class RemoteControlCar
{
    private int batteryPercentage = 100;
    private int distanceDrivenInMeters = 0;

    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            batteryPercentage--;
            distanceDrivenInMeters += 20;
        }
    }

    public string DistanceDisplay()
    {
        return $"Driven {distanceDrivenInMeters} meters";
    }

    public string BatteryDisplay()
    {
        if (batteryPercentage == 0)
        {
            return "Battery empty";
        }

        return $"Battery at {batteryPercentage}%";
    }

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }
}

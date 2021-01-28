class RemoteControlCar
{
    private int speed;
    private int battery = 100;
    private int batteryDrain;
    private int distance;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        return battery < batteryDrain;
    }

    public int DistanceDriven()
    {
        return distance;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            battery -= batteryDrain;
            distance += speed;
        }
    }

    public static RemoteControlCar TopOfTheLine()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    private int distance;

    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool CarCanFinish(RemoteControlCar car)
    {
        while (!car.BatteryDrained())
        {
            car.Drive();
        }

        return car.DistanceDriven() >= distance;
    }
}

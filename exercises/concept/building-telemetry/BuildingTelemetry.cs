using System;

public class RemoteControlCar
{
    private int batteryPercentage = 100;
    private int distanceDrivenInMeters = 0;
    private string[] sponsors = new string[0];
    private int latestSerialNum = 0;

    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            batteryPercentage -= 10;
            distanceDrivenInMeters += 2;
        }
    }

    public void SetSponsors(params string[] sponsors)
    {
        throw new NotImplementedException("Please implement the RemoteControlCar.SetSponsors() method");
    }

    public string DisplaySponsor(int sponsorNum)
    {
        throw new NotImplementedException("Please implement the RemoteControlCar.DisplaySponsor() method");
    }

    public bool GetTelemetryData(ref int serialNum,
        out int batteryPercentage, out int distanceDrivenInMeters)
    {
        throw new NotImplementedException("Please implement the RemoteControlCar.GetTelemetryData() method");
    }

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }
}

public class TelemetryClient
{
    private RemoteControlCar car;

    public TelemetryClient(RemoteControlCar car)
    {
        this.car = car;
    }

    public string GetBatteryUsagePerMeter(int serialNum)
    {
        throw new NotImplementedException("Please implement the TelemetryClient.GetBatteryUsagePerMeter() method");
    }
}

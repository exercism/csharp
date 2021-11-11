using Xunit;
using Exercism.Tests;

public class BuildingTelemetryTests
{
    [Fact]
    [Task(1)]
    public void DisplayNextSponsor_for_3_sponsors()
    {
        var car = RemoteControlCar.Buy();
        car.SetSponsors("Exercism", "Walker Industries", "Acme Co.");
        var sp1 = car.DisplaySponsor(sponsorNum: 0);
        var sp2 = car.DisplaySponsor(sponsorNum: 1);
        var sp3 = car.DisplaySponsor(sponsorNum: 2);
        Assert.Equal((sp1, sp2, sp3), ("Exercism", "Walker Industries", "Acme Co."));
    }

    [Fact]
    [Task(2)]
    public void GetTelemetryData_good()
    {
        var car = RemoteControlCar.Buy();
        car.Drive();
        car.Drive();
        int serialNum = 1;
        var result = car.GetTelemetryData(ref serialNum, out int batteryPercentage, out int distanceDrivenInMeters);
        Assert.True(result);
        Assert.Equal((1, 80, 4), (serialNum, batteryPercentage, distanceDrivenInMeters));
    }

    [Fact]
    [Task(2)]
    public void GetTelemetryData_bad()
    {
        var car = RemoteControlCar.Buy();
        int batteryPercentage, distanceDrivenInMeters;
        car.Drive();
        car.Drive();
        int serialNum = 4;
        car.GetTelemetryData(ref serialNum, out batteryPercentage, out distanceDrivenInMeters);
        serialNum = 1;
        bool result = car.GetTelemetryData(ref serialNum, out batteryPercentage, out distanceDrivenInMeters);
        Assert.False(result);
        Assert.Equal((4, -1, -1), (serialNum, batteryPercentage, distanceDrivenInMeters));
    }

    [Fact]
    [Task(3)]
    public void GetUsagePerMeter_good()
    {
        var car = RemoteControlCar.Buy();
        car.Drive(); car.Drive();
        var tc = new TelemetryClient(car);
        Assert.Equal("usage-per-meter=5", tc.GetBatteryUsagePerMeter(serialNum: 1));
    }

    [Fact]
    [Task(3)]
    public void GetUsagePerMeter_not_started()
    {
        var car = RemoteControlCar.Buy();
        var tc = new TelemetryClient(car);
        Assert.Equal("no data", tc.GetBatteryUsagePerMeter(serialNum: 1));
    }
}

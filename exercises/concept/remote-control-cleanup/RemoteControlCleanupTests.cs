using Xunit;
using Exercism.Tests;

public class RemoteControlCleanupTests
{
    [Fact]
    [Task(1)]
    public void ShowSponsor()
    {
        var car = new RemoteControlCar();
        string expected = "Walker Industries Inc.";
        car.Telemetry.ShowSponsor(expected);
        Assert.Equal(expected, car.CurrentSponsor);
    }

    [Fact]
    [Task(1)]
    public void ShowSpeed()
    {
        var car = new RemoteControlCar();
        string expected = "100 meters per second";
        car.Telemetry.SetSpeed(100, "mps");
        Assert.Equal(expected, car.GetSpeed());
    }
}

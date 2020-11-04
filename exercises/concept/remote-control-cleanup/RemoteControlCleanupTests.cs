using Xunit;

public class NestedTypeTests
{
    [Fact]
    public void ShowSponsor()
    {
        var car = new RemoteControlCar();
        string expected = "Walker Industries Inc.";
        car.Telemetry.ShowSponsor(expected);
        Assert.Equal(expected, car.CurrentSponsor);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ShowSpeed()
    {
        var car = new RemoteControlCar();
        string expected = "100 meters per second";
        decimal expectedAmount = 100;
        car.Telemetry.SetSpeed(100, "mps");
        Assert.Equal(expected, car.GetSpeed());
    }
}

using Xunit;

public class RemoteControlCarTests
{
    [Fact]
    public void BuyNewCarReturnsInstance()
    {
        var car = RemoteControlCar.Buy();
        Assert.NotNull(car);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void BuyNewCarReturnsNewCarEachTime()
    {
        var car1 = RemoteControlCar.Buy();
        var car2 = RemoteControlCar.Buy();
        Assert.NotSame(car2, car1);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void NewCarDistanceDisplay()
    {
        var car = new RemoteControlCar();
        Assert.Equal("Driven 0 meters", car.DistanceDisplay());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void NewCarBatteryDisplay()
    {
        var car = new RemoteControlCar();
        Assert.Equal("Battery at 100%", car.BatteryDisplay());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DistanceDisplayAfterDrivingOnce()
    {
        var car = new RemoteControlCar();
        car.Drive();
        Assert.Equal("Driven 20 meters", car.DistanceDisplay());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DistanceDisplayAfterDrivingMultipleTimes()
    {
        var car = new RemoteControlCar();

        for (var i = 0; i < 17; i++)
        {
            car.Drive();
        }

        Assert.Equal("Driven 340 meters", car.DistanceDisplay());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void BatteryDisplayAfterDrivingOnce()
    {
        var car = new RemoteControlCar();
        car.Drive();
        Assert.Equal("Battery at 99%", car.BatteryDisplay());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void BatteryDisplayAfterDrivingMultipleTimes()
    {
        var car = new RemoteControlCar();

        for (var i = 0; i < 23; i++)
        {
            car.Drive();
        }

        Assert.Equal("Battery at 77%", car.BatteryDisplay());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void BatteryDisplayWhenBatteryEmpty()
    {
        var car = new RemoteControlCar();

        // Drain the battery
        for (var i = 0; i < 100; i++)
        {
            car.Drive();
        }

        // Attempt to drive one more time (should not work)
        car.Drive();

        Assert.Equal("Battery empty", car.BatteryDisplay());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DistanceDisplayWhenBatteryEmpty()
    {
        var car = new RemoteControlCar();

        // Drain the battery
        for (var i = 0; i < 100; i++)
        {
            car.Drive();
        }

        // Attempt to drive one more time (should not work)
        car.Drive();

        Assert.Equal("Driven 2000 meters", car.DistanceDisplay());
    }
}

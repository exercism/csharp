using Xunit;
using Exercism.Tests;

public class RemoteControlCarTests
{
    [Fact]
    public void Buy_new_car_returns_instance()
    {
        var car = RemoteControlCar.Buy();
        Assert.NotNull(car);
    }

    [Fact]
    public void Buy_new_car_returns_new_car_each_time()
    {
        var car1 = RemoteControlCar.Buy();
        var car2 = RemoteControlCar.Buy();
        Assert.NotSame(car2, car1);
    }

    [Fact]
    public void New_car_distance_display()
    {
        var car = new RemoteControlCar();
        Assert.Equal("Driven 0 meters", car.DistanceDisplay());
    }

    [Fact]
    public void New_car_battery_display()
    {
        var car = new RemoteControlCar();
        Assert.Equal("Battery at 100%", car.BatteryDisplay());
    }

    [Fact]
    public void Distance_display_after_driving_once()
    {
        var car = new RemoteControlCar();
        car.Drive();
        Assert.Equal("Driven 20 meters", car.DistanceDisplay());
    }

    [Fact]
    public void Distance_display_after_driving_multiple_times()
    {
        var car = new RemoteControlCar();

        for (var i = 0; i < 17; i++)
        {
            car.Drive();
        }

        Assert.Equal("Driven 340 meters", car.DistanceDisplay());
    }

    [Fact]
    public void Battery_display_after_driving_once()
    {
        var car = new RemoteControlCar();
        car.Drive();
        Assert.Equal("Battery at 99%", car.BatteryDisplay());
    }

    [Fact]
    public void Battery_display_after_driving_multiple_times()
    {
        var car = new RemoteControlCar();

        for (var i = 0; i < 23; i++)
        {
            car.Drive();
        }

        Assert.Equal("Battery at 77%", car.BatteryDisplay());
    }

    [Fact]
    public void Battery_display_when_battery_empty()
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

    [Fact]
    public void Distance_display_when_battery_empty()
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

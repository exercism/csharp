using Xunit;

public class RemoteControlCarTests
{
    [Fact]
    public void NewRemoteControlCarHasNotDrivenAnyDistance()
    {
        int speed = 10;
        int batteryDrain = 2;
        var car = new RemoteControlCar(speed, batteryDrain);

        Assert.Equal(0, car.DistanceDriven());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DriveIncreasesDistanceDrivenWithSpeed()
    {
        int speed = 5;
        int batteryDrain = 1;
        var car = new RemoteControlCar(speed, batteryDrain);

        car.Drive();

        Assert.Equal(5, car.DistanceDriven());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DriveDoesNotIncreaseDistanceDrivenWhenBatteryDrained()
    {
        int speed = 9;
        int batteryDrain = 50;
        var car = new RemoteControlCar(speed, batteryDrain);

        // Drain the battery
        car.Drive();
        car.Drive();

        // One extra drive attempt (should not succeed)
        car.Drive();

        Assert.Equal(18, car.DistanceDriven());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void NewRemoteControlCarBatteryIsNotDrained()
    {
        int speed = 15;
        int batteryDrain = 3;
        var car = new RemoteControlCar(speed, batteryDrain);

        Assert.False(car.BatteryDrained());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DriveToAlmostDrainBattery()
    {
        int speed = 2;
        int batteryDrain = 1;
        var car = new RemoteControlCar(speed, batteryDrain);

        // Almost drain the battery
        for (var i = 0; i < 99; i++)
        {
            car.Drive();
        }

        Assert.False(car.BatteryDrained());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DriveUntilBatteryIsDrained()
    {
        int speed = 2;
        int batteryDrain = 1;
        var car = new RemoteControlCar(speed, batteryDrain);

        // Drain the battery
        for (var i = 0; i < 100; i++)
        {
            car.Drive();
        }

        Assert.True(car.BatteryDrained());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TopOfTheLineCarHasNotDrivenAnyDistance()
    {
        var car = RemoteControlCar.TopOfTheLine();
        Assert.Equal(0, car.DistanceDriven());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TopOfTheLineCarHasBatteryNotDrained()
    {
        var car = RemoteControlCar.TopOfTheLine();
        Assert.False(car.BatteryDrained());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TopOfTheLineCarHasCorrectSpeed()
    {
        var car = RemoteControlCar.TopOfTheLine();
        car.Drive();
        Assert.Equal(50, car.DistanceDriven());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TopOfTheLineHasCorrectBatteryDrain()
    {
        var car = RemoteControlCar.TopOfTheLine();

        // The battery is almost drained
        for (var i = 0; i < 24; i++)
        {
            car.Drive();
        }

        Assert.False(car.BatteryDrained());

        // Drain the battery
        car.Drive();

        Assert.True(car.BatteryDrained());
    }
}

public class RaceTrackTests
{
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CarCanFinishWithCarThatCanEasilyFinish()
    {
        int speed = 10;
        int batteryDrain = 2;
        var car = new RemoteControlCar(speed, batteryDrain);

        int distance = 100;
        var race = new RaceTrack(distance);

        Assert.True(race.CarCanFinish(car));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CarCanFinishWithCarThatCanJustFinish()
    {
        int speed = 2;
        int batteryDrain = 10;
        var car = new RemoteControlCar(speed, batteryDrain);

        int distance = 20;
        var race = new RaceTrack(distance);

        Assert.True(race.CarCanFinish(car));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CarCanFinishWithCarThatJustCannotFinish()
    {
        int speed = 3;
        int batteryDrain = 20;
        var car = new RemoteControlCar(speed, batteryDrain);

        int distance = 16;
        var race = new RaceTrack(distance);

        Assert.False(race.CarCanFinish(car));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CarCanFinishWithCarThatCannotFinish()
    {
        int speed = 1;
        int batteryDrain = 20;
        var car = new RemoteControlCar(speed, batteryDrain);

        int distance = 678;
        var race = new RaceTrack(distance);

        Assert.False(race.CarCanFinish(car));
    }
}

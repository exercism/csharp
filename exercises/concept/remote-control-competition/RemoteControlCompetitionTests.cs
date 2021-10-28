using System.Collections.Generic;
using Xunit;
using Exercism.Tests;

public class RemoteControlCompetitionTests
{
    [Fact]
    [Task(1)]
    public void Race()
    {
        var productionCar = new ProductionRemoteControlCar();
        var experimentalCar = new ExperimentalRemoteControlCar();
        TestTrack.Race((IRemoteControlCar)productionCar);
        TestTrack.Race((IRemoteControlCar)productionCar);
        TestTrack.Race((IRemoteControlCar)experimentalCar);
        TestTrack.Race((IRemoteControlCar)experimentalCar);
        Assert.Equal(20, experimentalCar.DistanceTravelled - productionCar.DistanceTravelled);
    }
    
    [Fact]
    [Task(2)]
    public void EnsureInterfaceExposesDistanceTravelled()
    {
        var car = Assert.IsAssignableFrom<IRemoteControlCar>(new ProductionRemoteControlCar());
        car.Drive();
        Assert.Equal(10, car.DistanceTravelled);
    }

    [Fact]
    [Task(2)]
    public void EnsureCarsAreComparable()
    {
        var fast = new ProductionRemoteControlCar();
        var medium = new ProductionRemoteControlCar();
        var slow = new ProductionRemoteControlCar();
        fast.NumberOfVictories = 3;
        medium.NumberOfVictories = 2;
        slow.NumberOfVictories = 1;
        var cars = new List<ProductionRemoteControlCar> { fast, slow, medium };
        cars.Sort();
        Assert.Equal(new ProductionRemoteControlCar[] { slow, medium, fast }, cars);
    }

    [Fact]
    [Task(3)]
    public void RankCars()
    {
        var prc1 = new ProductionRemoteControlCar();
        var prc2 = new ProductionRemoteControlCar();
        prc1.NumberOfVictories = 3;
        prc2.NumberOfVictories = 2;
        var rankings = TestTrack.GetRankedCars(prc1, prc2);
        Assert.Same(prc1, rankings[1]);
    }
}

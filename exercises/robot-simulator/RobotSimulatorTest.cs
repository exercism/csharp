using Xunit;

public class RobotSimulatorTest
{
    [Fact]
    public void Turn_right_edge_case()
    {
        var robot = new RobotSimulator(Bearing.West, new Coordinate(0, 0));
        robot.TurnRight();
        Assert.That(robot.Bearing, Is.EqualTo(Bearing.North));
    }

    [Fact(Skip="Remove to run test")]
    public void Turn_left_edge_case()
    {
        var robot = new RobotSimulator(Bearing.North, new Coordinate(0, 0));
        robot.TurnLeft();
        Assert.That(robot.Bearing, Is.EqualTo(Bearing.West));
    }

    [Fact(Skip="Remove to run test")]
    public void Robbie()
    {
        var robbie = new RobotSimulator(Bearing.East, new Coordinate(-2, 1));
        Assert.That(robbie.Bearing, Is.EqualTo(Bearing.East));
        Assert.That(robbie.Coordinate, Is.EqualTo(new Coordinate(-2, 1)));

        robbie.Simulate("RLAALAL");
        Assert.That(robbie.Bearing, Is.EqualTo(Bearing.West));
        Assert.That(robbie.Coordinate, Is.EqualTo(new Coordinate(0, 2)));
    }

    [Fact(Skip="Remove to run test")]
    public void Clutz()
    {
        var clutz = new RobotSimulator(Bearing.North, new Coordinate(0, 0));
        clutz.Simulate("LAAARALA");
        Assert.That(clutz.Bearing, Is.EqualTo(Bearing.West));
        Assert.That(clutz.Coordinate, Is.EqualTo(new Coordinate(-4, 1)));
    }

    [Fact(Skip="Remove to run test")]
    public void Sphero()
    {
        var sphero = new RobotSimulator(Bearing.East, new Coordinate(2, -7));
        sphero.Simulate("RRAAAAALA");
        Assert.That(sphero.Bearing, Is.EqualTo(Bearing.South));
        Assert.That(sphero.Coordinate, Is.EqualTo(new Coordinate(-3, -8)));
    }

    [Fact(Skip="Remove to run test")]
    public void Roomba()
    {
        var roomba = new RobotSimulator(Bearing.South, new Coordinate(8, 4));
        roomba.Simulate("LAAARRRALLLL");
        Assert.That(roomba.Bearing, Is.EqualTo(Bearing.North));
        Assert.That(roomba.Coordinate, Is.EqualTo(new Coordinate(11, 5)));
    }
}
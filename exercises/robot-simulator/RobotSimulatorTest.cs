using Xunit;

public class RobotSimulatorTest
{
    [Fact]
    public void Turn_right_edge_case()
    {
        var robot = new RobotSimulator(Bearing.West, new Coordinate(0, 0));
        robot.TurnRight();
        Assert.Equal(Bearing.North, robot.Bearing);
    }

    [Fact(Skip = "Remove to run test")]
    public void Turn_left_edge_case()
    {
        var robot = new RobotSimulator(Bearing.North, new Coordinate(0, 0));
        robot.TurnLeft();
        Assert.Equal(Bearing.West, robot.Bearing);
    }

    [Fact(Skip = "Remove to run test")]
    public void Robbie()
    {
        var robbie = new RobotSimulator(Bearing.East, new Coordinate(-2, 1));
        Assert.Equal(Bearing.East, robbie.Bearing);
        Assert.Equal(new Coordinate(-2, 1), robbie.Coordinate);

        robbie.Simulate("RLAALAL");
        Assert.Equal(Bearing.West, robbie.Bearing);
        Assert.Equal(new Coordinate(0, 2), robbie.Coordinate);
    }

    [Fact(Skip = "Remove to run test")]
    public void Clutz()
    {
        var clutz = new RobotSimulator(Bearing.North, new Coordinate(0, 0));
        clutz.Simulate("LAAARALA");
        Assert.Equal(Bearing.West, clutz.Bearing);
        Assert.Equal(new Coordinate(-4, 1), clutz.Coordinate);
    }

    [Fact(Skip = "Remove to run test")]
    public void Sphero()
    {
        var sphero = new RobotSimulator(Bearing.East, new Coordinate(2, -7));
        sphero.Simulate("RRAAAAALA");
        Assert.Equal(Bearing.South, sphero.Bearing);
        Assert.Equal(new Coordinate(-3, -8), sphero.Coordinate);
    }

    [Fact(Skip = "Remove to run test")]
    public void Roomba()
    {
        var roomba = new RobotSimulator(Bearing.South, new Coordinate(8, 4));
        roomba.Simulate("LAAARRRALLLL");
        Assert.Equal(Bearing.North, roomba.Bearing);
        Assert.Equal(new Coordinate(11, 5), roomba.Coordinate);
    }
}
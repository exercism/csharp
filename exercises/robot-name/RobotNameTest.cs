using Xunit;

public class RobotNameTest
{
    private readonly Robot robot = new Robot();

    [Fact]
    public void Robot_has_a_name()
    {
        Assert.Matches(@"[A-Z]{2}\d{3}", robot.Name);
    }

    [Fact]
    public void Name_is_the_same_each_time()
    {
        Assert.Equal(robot.Name, robot.Name);
    }

    [Fact]
    public void Different_robots_have_different_names()
    {
        var robot2 = new Robot();
        Assert.NotEqual(robot2.Name, robot.Name);
    }

    [Fact]
    public void Can_reset_the_name()
    {
        var originalName = robot.Name;
        robot.Reset();
        Assert.NotEqual(originalName, robot.Name);
    }
}
using Xunit;

public class RobotNameTest
{
    private Robot robot;

    [SetUp]
    public void Setup()
    {
        robot = new Robot();
    }

    [Fact]
    public void Robot_has_a_name()
    {
        StringAssert.IsMatch(@"[A-Z]{2}\d{3}", robot.Name);
    }

    [Fact(Skip="Remove to run test")]
    public void Name_is_the_same_each_time()
    {
        Assert.Equal(robot.Name, robot.Name);
    }

    [Fact(Skip="Remove to run test")]
    public void Different_robots_have_different_names()
    {
        var robot2 = new Robot();
        Assert.That(robot.Name, Is.Not.EqualTo(robot2.Name));
    }

    [Fact(Skip="Remove to run test")]
    public void Can_reset_the_name()
    {
        var originalName = robot.Name;
        robot.Reset();
        Assert.That(robot.Name, Is.Not.EqualTo(originalName));
    }
}
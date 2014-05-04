using NUnit.Framework;

[TestFixture]
public class RobotNameTest
{
    private Robot robot;

    [SetUp]
    public void Setup()
    {
        robot = new Robot();
    }

    [Test]
    public void RobotHasAName()
    {
        StringAssert.IsMatch(@"\w{2}\d{3}", robot.Name);
    }

    [Test]
    public void NameIsTheSameEachTime()
    {
        Assert.That(robot.Name, Is.EqualTo(robot.Name));
    }

    [Test]
    public void DifferentRobotsHaveDifferentNames()
    {
        var robot2 = new Robot();
        Assert.That(robot.Name, Is.Not.EqualTo(robot2.Name));
    }

    [Test]
    public void CanResetTheName()
    {
        var originalName = robot.Name;
        robot.Reset();
        Assert.That(robot.Name, Is.Not.EqualTo(originalName));
    }
}
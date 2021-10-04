using System.Linq;
using System.Collections.Generic;
using Xunit;

public class RobotNameTests
{
    private readonly Robot robot = new Robot();

    [Fact]
    public void Robot_has_a_name()
    {
        Assert.Matches(@"^[A-Z]{2}\d{3}$", robot.Name);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Name_is_the_same_each_time()
    {
        Assert.Equal(robot.Name, robot.Name);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Different_robots_have_different_names()
    {
        var robot2 = new Robot();
        Assert.NotEqual(robot2.Name, robot.Name);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_reset_the_name()
    {
        var originalName = robot.Name;
        robot.Reset();
        Assert.NotEqual(originalName, robot.Name);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void After_reset_the_name_is_valid()
    {
        robot.Reset();
        Assert.Matches(@"^[A-Z]{2}\d{3}$", robot.Name);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Robot_names_are_unique()
    {
        const int robotsCount = 10_000;
        var robots = new List<Robot>(robotsCount); // Needed to keep a reference to the robots as IDs of recycled robots may be re-issued
        var names = new HashSet<string>(robotsCount);
        for (int i = 0; i < robotsCount; i++) {
            var robot = new Robot();
            robots.Add(robot);
            Assert.True(names.Add(robot.Name));
            Assert.Matches(@"^[A-Z]{2}\d{3}$", robot.Name);
        }
    }
    
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Robot_names_should_generate_edge_case_a()
    {
        const int robotsCount = 10_000;
        var robots = Enumerable.Range(0,robotsCount).Select( x => new Robot());
        Assert.Contains(robots, robot => robot.Name.Contains('A'));
    }
    
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Robot_names_should_generate_edge_case_z()
    {
        const int robotsCount = 10_000;
        var robots = Enumerable.Range(0,robotsCount).Select( x => new Robot());
        Assert.Contains(robots, robot => robot.Name.Contains('Z'));
    }
}

using System;
using System.Reflection;
using Xunit;
using Exercism.Tests;

public class LandGrabInSpaceTests
{
    [Fact]
    [Task(2)]
    public void IsClaimed_yes()
    {
        var ch = new ClaimsHandler();
        ch.StakeClaim(CreatePlot(new Coord(1, 1), new Coord(2, 1), new Coord(1, 2), new Coord(2, 2)));
        var claimed = ch.IsClaimStaked(CreatePlot(new Coord(1, 1), new Coord(2, 1), new Coord(1, 2), new Coord(2, 2)));
        Assert.True(claimed);
    }

    [Fact]
    [Task(2)]
    public void IsClaimed_no()
    {
        var ch = new ClaimsHandler();
        ch.StakeClaim(CreatePlot(new Coord(1, 1), new Coord(2, 1), new Coord(1, 2), new Coord(2, 2)));
        var claimed = ch.IsClaimStaked(CreatePlot(new Coord(1, 0), new Coord(2, 1), new Coord(1, 2), new Coord(2, 2)));
        Assert.False(claimed);
    }

    [Fact]
    [Task(3)]
    public void IsLastClaim_yes()
    {
        var ch = new ClaimsHandler();
        ch.StakeClaim(CreatePlot(new Coord(1, 1), new Coord(2, 1), new Coord(1, 2), new Coord(2, 2)));
        ch.StakeClaim(CreatePlot(new Coord(10, 1), new Coord(20, 1), new Coord(10, 2), new Coord(20, 2)));
        var lastClaim = ch.IsLastClaim(CreatePlot(new Coord(10, 1), new Coord(20, 1), new Coord(10, 2), new Coord(20, 2)));
        Assert.True(lastClaim);
    }

    [Fact]
    [Task(3)]
    public void IsLastClaim_no()
    {
        var ch = new ClaimsHandler();
        ch.StakeClaim(CreatePlot(new Coord(10, 1), new Coord(20, 1), new Coord(10, 2), new Coord(20, 2)));
        ch.StakeClaim(CreatePlot(new Coord(1, 1), new Coord(2, 1), new Coord(1, 2), new Coord(2, 2)));
        var lastClaim = ch.IsLastClaim(CreatePlot(new Coord(10, 1), new Coord(20, 1), new Coord(10, 2), new Coord(20, 2)));
        Assert.False(lastClaim);
    }

    [Fact]
    [Task(4)]
    public void GetLongestSide()
    {
        var ch = new ClaimsHandler();
        var longer = CreatePlot(new Coord(10, 1), new Coord(20, 1), new Coord(10, 2), new Coord(20, 2));
        var shorter = CreatePlot(new Coord(1, 1), new Coord(2, 1), new Coord(1, 2), new Coord(2, 2));
        ch.StakeClaim(longer);
        ch.StakeClaim(shorter);
        Assert.Equal(longer, ch.GetClaimWithLongestSide());
    }

    [Fact]
    [Task(4)]
    public void GetLongestSideReverseInsertionOrder()
    {
        var ch = new ClaimsHandler();
        var longer = CreatePlot(new Coord(10, 1), new Coord(20, 1), new Coord(10, 2), new Coord(20, 2));
        var shorter = CreatePlot(new Coord(1, 1), new Coord(2, 1), new Coord(1, 2), new Coord(2, 2));
        ch.StakeClaim(shorter);
        ch.StakeClaim(longer);
        Assert.Equal(longer, ch.GetClaimWithLongestSide());
    }

    private Plot CreatePlot(Coord coord1, Coord coord2, Coord coord3, Coord coord4)
    {
        Type plotType = typeof(Plot);
        Type[] types = new Type[] { typeof(Coord), typeof(Coord), typeof(Coord), typeof(Coord) };
        ConstructorInfo constructorInfoObj = plotType.GetConstructor(types);
        if (constructorInfoObj != null)
        {
            return (Plot)constructorInfoObj.Invoke(new object[] { coord1, coord2, coord3, coord4 });
        }

        else
        {
            throw new InvalidOperationException("You need to implement a constructor for the struct Plot.  The constructor must take 4 co-ordinates.  No such constructor can be found.");
        }
    }
}

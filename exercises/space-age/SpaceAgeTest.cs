// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class SpaceAgeTest
{
    [Fact]
    public void Age_on_earth()
    {
        var sut = new SpaceAge(1000000000);
        Assert.Equal(31.69, sut.OnEarth());
    }

    [Fact(Skip = "Remove to run test")]
    public void Age_on_mercury()
    {
        var sut = new SpaceAge(2134835688);
        Assert.Equal(280.88, sut.OnMercury());
    }

    [Fact(Skip = "Remove to run test")]
    public void Age_on_venus()
    {
        var sut = new SpaceAge(189839836);
        Assert.Equal(9.78, sut.OnVenus());
    }

    [Fact(Skip = "Remove to run test")]
    public void Age_on_mars()
    {
        var sut = new SpaceAge(2329871239);
        Assert.Equal(39.25, sut.OnMars());
    }

    [Fact(Skip = "Remove to run test")]
    public void Age_on_jupiter()
    {
        var sut = new SpaceAge(901876382);
        Assert.Equal(2.41, sut.OnJupiter());
    }

    [Fact(Skip = "Remove to run test")]
    public void Age_on_saturn()
    {
        var sut = new SpaceAge(3000000000);
        Assert.Equal(3.23, sut.OnSaturn());
    }

    [Fact(Skip = "Remove to run test")]
    public void Age_on_uranus()
    {
        var sut = new SpaceAge(3210123456);
        Assert.Equal(1.21, sut.OnUranus());
    }

    [Fact(Skip = "Remove to run test")]
    public void Age_on_neptune()
    {
        var sut = new SpaceAge(8210123456);
        Assert.Equal(1.58, sut.OnNeptune());
    }
}
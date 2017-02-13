using Xunit;

public class SpaceAgeTest
{
    [Fact(Skip = "Remove to run test")]
    public void Age_on_earth()
    {
        var age = new SpaceAge(1000000000);
        Assert.Equal(31.69, age.OnEarth());
    }

    [Fact(Skip = "Remove to run test")]
    public void Age_on_mercury()
    {
        var age = new SpaceAge(2134835688);
        Assert.Equal(67.65, age.OnEarth());
        Assert.Equal(280.88, age.OnMercury());
    }

    [Fact(Skip = "Remove to run test")]
    public void Age_on_venus()
    {
        var age = new SpaceAge(189839836);
        Assert.Equal(6.02, age.OnEarth());
        Assert.Equal(9.78, age.OnVenus());
    }

    [Fact(Skip = "Remove to run test")]
    public void Age_on_mars()
    {
        var age = new SpaceAge(2329871239);
        Assert.Equal(73.83, age.OnEarth());
        Assert.Equal(39.25, age.OnMars());
    }

    [Fact(Skip = "Remove to run test")]
    public void Age_on_jupiter()
    {
        var age = new SpaceAge(901876382);
        Assert.Equal(28.58, age.OnEarth());
        Assert.Equal(2.41, age.OnJupiter());
    }

    [Fact(Skip = "Remove to run test")]
    public void Age_on_saturn()
    {
        var age = new SpaceAge(3000000000);
        Assert.Equal(95.06, age.OnEarth());
        Assert.Equal(3.23, age.OnSaturn());
    }

    [Fact(Skip = "Remove to run test")]
    public void Age_on_uranus()
    {
        var age = new SpaceAge(3210123456);
        Assert.Equal(101.72, age.OnEarth());
        Assert.Equal(1.21, age.OnUranus());
    }

    [Fact(Skip = "Remove to run test")]
    public void Age_on_neptune()
    {
        var age = new SpaceAge(8210123456);
        Assert.Equal(260.16, age.OnEarth());
        Assert.Equal(1.58, age.OnNeptune());
    }
}

using NUnit.Framework;

[TestFixture]
public class SpaceAgeTest
{
    [Test]
    public void Age_in_seconds()
    {
        var age = new SpaceAge(1000000);
        Assert.That(age.Seconds, Is.EqualTo(1000000));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Age_on_earth()
    {
        var age = new SpaceAge(1000000000);
        Assert.That(age.OnEarth(), Is.EqualTo(31.69).Within(1E-02));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Age_on_mercury()
    {
        var age = new SpaceAge(2134835688);
        Assert.That(age.OnEarth(), Is.EqualTo(67.65).Within(1E-02));
        Assert.That(age.OnMercury(), Is.EqualTo(280.88).Within(1E-02));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Age_on_venus()
    {
        var age = new SpaceAge(189839836);
        Assert.That(age.OnEarth(), Is.EqualTo(6.02).Within(1E-02));
        Assert.That(age.OnVenus(), Is.EqualTo(9.78).Within(1E-02));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Age_on_mars()
    {
        var age = new SpaceAge(2329871239);
        Assert.That(age.OnEarth(), Is.EqualTo(73.83).Within(1E-02));
        Assert.That(age.OnMars(), Is.EqualTo(39.25).Within(1E-02));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Age_on_jupiter()
    {
        var age = new SpaceAge(901876382);
        Assert.That(age.OnEarth(), Is.EqualTo(28.58).Within(1E-02));
        Assert.That(age.OnJupiter(), Is.EqualTo(2.41).Within(1E-02));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Age_on_saturn()
    {
        var age = new SpaceAge(3000000000);
        Assert.That(age.OnEarth(), Is.EqualTo(95.06).Within(1E-02));
        Assert.That(age.OnSaturn(), Is.EqualTo(3.23).Within(1E-02));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Age_on_uranus()
    {
        var age = new SpaceAge(3210123456);
        Assert.That(age.OnEarth(), Is.EqualTo(101.72).Within(1E-02));
        Assert.That(age.OnUranus(), Is.EqualTo(1.21).Within(1E-02));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Age_on_neptune()
    {
        var age = new SpaceAge(8210123456);
        Assert.That(age.OnEarth(), Is.EqualTo(260.16).Within(1E-02));
        Assert.That(age.OnNeptune(), Is.EqualTo(1.58).Within(1E-02));
    }
}
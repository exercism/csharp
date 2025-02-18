using Xunit;
using Exercism.Tests;

public class DeveloperPrivilegesTests
{
    [Fact]
    [Task(1)]
    public void GetAdmin()
    {
        var authenticator = new Authenticator();
        var admin = authenticator.Admin;

        Assert.NotNull(admin);
        Assert.Equal("admin@ex.ism", admin.Email);
        Assert.Equal("green", admin.FacialFeatures.EyeColor);
        Assert.Equal(0.9M, admin.FacialFeatures.PhiltrumWidth, precision: 1);
        Assert.Equal("Chanakya", admin.NameAndAddress[0]);
        Assert.Equal("Mumbai", admin.NameAndAddress[1]);
        Assert.Equal("India", admin.NameAndAddress[2]);
    }

    [Fact]
    [Task(2)]
    public void GetBertrand()
    {
        var authenticator = new Authenticator();
        var bertrand = authenticator.Developers?["Bertrand"];

        Assert.NotNull(bertrand);
        Assert.Equal("bert@ex.ism", bertrand.Email);
        Assert.Equal("blue", bertrand.FacialFeatures.EyeColor);
        Assert.Equal(0.8M, bertrand.FacialFeatures.PhiltrumWidth, precision: 1);
        Assert.Equal("Bertrand", bertrand.NameAndAddress[0]);
        Assert.Equal("Paris", bertrand.NameAndAddress[1]);
        Assert.Equal("France", bertrand.NameAndAddress[2]);
    }

    [Fact]
    [Task(3)]
    public void GetAnders()
    {
        var authenticator = new Authenticator();
        var anders = authenticator.Developers?["Anders"];

        Assert.NotNull(anders);
        Assert.Equal("anders@ex.ism", anders.Email);
        Assert.Equal("brown", anders.FacialFeatures.EyeColor);
        Assert.Equal(0.85M, anders.FacialFeatures.PhiltrumWidth, precision: 2);
        Assert.Equal("Anders", anders.NameAndAddress[0]);
        Assert.Equal("Redmond", anders.NameAndAddress[1]);
        Assert.Equal("USA", anders.NameAndAddress[2]);
    }
}

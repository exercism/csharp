using System;
using Xunit;

public class ObjectInitializationTests
{
    [Fact]
    public void GetAdmin()
    {
        var authenticator = new Authenticator();
        var admin = authenticator.Admin;
        string[] actual =
        {
            admin?.Email,
            admin?.FacialFeatures.EyeColor,
            admin?.FacialFeatures.PhiltrumWidth.ToString(),
            admin?.NameAndAddress[0]
        };
        string[] expected =
        {
            "admin@ex.ism",
            "green",
            "0.9",
            "Chanakya"
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void GetDevelopers()
    {
        var authenticator = new Authenticator();
        var developers = authenticator.Developers;
        string[] actual =
        {
            developers["Bertrand"]?.Email,
            developers["Bertrand"]?.FacialFeatures.EyeColor,
            developers["Anders"]?.FacialFeatures.PhiltrumWidth.ToString(),
            developers["Anders"]?.NameAndAddress[1]
        };
        string[] expected =
        {
            "bert@ex.ism",
            "blue",
            "0.85",
            "Redmond"
        };
        Assert.Equal(expected, actual);
    }
}

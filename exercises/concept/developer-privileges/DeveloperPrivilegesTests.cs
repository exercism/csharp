using System;
using Xunit;
using Exercism.Tests;
using System.Globalization;

public class DeveloperPrivilegesTests
{
    [Fact]
    [Task(1)]
    public void GetAdmin()
    {
        var authenticator = new Authenticator();
        var admin = authenticator.Admin;
        string[] actual =
        {
            admin?.Email,
            admin?.FacialFeatures.EyeColor,
            admin?.FacialFeatures.PhiltrumWidth.ToString(CultureInfo.InvariantCulture),
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

    [Fact]
    [Task(2)]
    public void GetDevelopers()
    {
        var authenticator = new Authenticator();
        var developers = authenticator.Developers;
        string[] actual =
        {
            developers["Bertrand"]?.Email,
            developers["Bertrand"]?.FacialFeatures.EyeColor,
            developers["Anders"]?.FacialFeatures.PhiltrumWidth.ToString(CultureInfo.InvariantCulture),
            developers["Anders"]?.NameAndAddress[1]
        };
        string[] expected =
        {
            "bert@ex.ism",
            "blue",
            "0.8",
            "Paris"
        };
        Assert.Equal(expected, actual);
    }
}

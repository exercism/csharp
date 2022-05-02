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
    public void GetDevelopers_Bertrand()
    {
        var authenticator = new Authenticator();
        var developers = authenticator.Developers;
        string[] actual =
        {
            developers["Bertrand"]?.Email,
            developers["Bertrand"]?.FacialFeatures.EyeColor,
            developers["Bertrand"]?.FacialFeatures.PhiltrumWidth.ToString(CultureInfo.InvariantCulture),
            developers["Bertrand"]?.NameAndAddress[0],
            developers["Bertrand"]?.NameAndAddress[1],
            developers["Bertrand"]?.NameAndAddress[2]
        };
        string[] expected =
        {
            "bert@ex.ism",
            "blue",
            "0.8",
            "Bertrand",
            "Paris",
            "France"
        };
        Assert.Equal(expected, actual);
    }

    [Fact]
    [Task(3)]
    public void GetDevelopers_Anders()
    {
        var authenticator = new Authenticator();
        var developers = authenticator.Developers;
        string[] actual =
        {
            developers["Anders"]?.Email,
            developers["Anders"]?.FacialFeatures.EyeColor,
            developers["Anders"]?.FacialFeatures.PhiltrumWidth.ToString(CultureInfo.InvariantCulture),
            developers["Anders"]?.NameAndAddress[0],
            developers["Anders"]?.NameAndAddress[1],
            developers["Anders"]?.NameAndAddress[2]
        };
        string[] expected =
        {
            "anders@ex.ism",
            "brown",
            "0.85",
            "Anders",
            "Redmond",
            "USA"
        };
        Assert.Equal(expected, actual);
    }
}

using System;
using System.Collections.Generic;
using Xunit;

public class ObjectInitializationTests
{
    [Fact]
    public void GetAdmin()
    {
        var admin = new Identity {EyeColor = "green", Email = "admin@ex.ism"};
        var authenticator = new Authenticator(admin);
        Assert.Equal(admin, authenticator.Admin);
    }

    [Fact]
    public void GetDevelopers()
    {
        var authenticator = new Authenticator(new Identity {EyeColor = "green", Email = "admin@ex.ism"});
        var devs = authenticator.GetDevelopers() as IDictionary<string, Identity>;
        bool?[] actual = {devs != null, devs?.Count == 2, devs?["Anders"].EyeColor == "brown"};
        bool?[] expected = {true, true, true};
        Assert.Equal(expected, actual);
    }
}

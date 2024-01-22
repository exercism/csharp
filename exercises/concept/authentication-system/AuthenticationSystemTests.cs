using System;
using System.Collections.Generic;
using Xunit;
using Exercism.Tests;

public class AuthenticationSystemTests
{
    [Fact]
    [Task(4)]
    public void GetAdmin()
    {
        var admin = new Identity { EyeColor = "green", Email = "admin@ex.ism" };
        var authenticator = new Authenticator(admin);
        Assert.Equal(admin, authenticator.Admin);
    }

    [Fact]
    [Task(4)]
    public void CheckAdminCannotBeTampered()
    {
        var adminEmail = "admin@ex.ism";
        var admin = new Identity { EyeColor = "green", Email = adminEmail };
        var authenticator = new Authenticator(admin);
        var tamperedAdmin = authenticator.Admin;
        tamperedAdmin.Email = "admin@hack.ed";
        Assert.Equal(adminEmail, authenticator.Admin.Email);
    }

    [Fact]
    [Task(5)]
    public void GetDevelopers()
    {
        var authenticator = new Authenticator(new Identity { EyeColor = "green", Email = "admin@ex.ism" });
        var devs = authenticator.GetDevelopers() as IDictionary<string, Identity>;
        bool?[] actual = { devs != null, devs?.Count == 2, devs?["Anders"].EyeColor == "brown" };
        bool?[] expected = { true, true, true };
        Assert.Equal(expected, actual);
    }

    [Fact]
    [Task(5)]
    public void CheckDevelopersCannotBeTampered()
    {
        var authenticator = new Authenticator(new Identity { EyeColor = "green", Email = "admin@ex.ism" });
        IDictionary<string, Identity> devs = authenticator.GetDevelopers();

        Identity tamperedDev = new Identity { EyeColor = "grey", Email = "anders@hack.ed" };
        Assert.Throws<NotSupportedException>(() => devs["Anders"] = tamperedDev);
    }
}

using Xunit;
using Exercism.Tests;

public class Faceid2Tests
{
    [Fact]
    [Task(1)]
    public void AreSameFace_yes()
    {
        Assert.True(Authenticator.AreSameFace(new FacialFeatures("green", 0.9m),
            new FacialFeatures("green", 0.9m)));
    }

    [Fact]
    [Task(1)]
    public void AreSameFace_no()
    {
        Assert.False(Authenticator.AreSameFace(new FacialFeatures("green", 0.9m),
            new FacialFeatures("blue", 0.9m)));
    }

    [Fact]
    [Task(2)]
    public void IsAdmin_with_admin()
    {
        var authenticator = new Authenticator();
        Assert.True(authenticator.IsAdmin(new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m))));
    }

    [Fact]
    [Task(2)]
    public void IsAdmin_with_wrong_email()
    {
        var authenticator = new Authenticator();
        Assert.False(authenticator.IsAdmin(new Identity("admin@thecompetition.com", new FacialFeatures("green", 0.9m))));
    }

    [Fact]
    [Task(2)]
    public void IsAdmin_with_wrong_face()
    {
        var authenticator = new Authenticator();
        Assert.False(authenticator.IsAdmin(new Identity("admin@exerc.ism", new FacialFeatures("blue", 0.9m))));
    }

    [Fact]
    [Task(3)]
    public void Register_new_identity()
    {
        var authenticator = new Authenticator();
        Assert.True(authenticator.Register(new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m))));
    }

    [Fact]
    [Task(3)]
    public void Register_existing_identity()
    {
        var authenticator = new Authenticator();
        authenticator.Register(new Identity("tunde@thecompetition.com", new FacialFeatures("blue", 0.9m)));
        Assert.False(authenticator.Register(new Identity("tunde@thecompetition.com", new FacialFeatures("blue", 0.9m))));
    }

    [Fact]
    [Task(3)]
    public void IsRegistered_existing_identity()
    {
        var authenticator = new Authenticator();
        authenticator.Register(new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m)));
        Assert.True(authenticator.IsRegistered(new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m))));
    }

    [Fact]
    [Task(4)]
    public void IsRegistered_non_existent_identity()
    {
        var authenticator = new Authenticator();
        authenticator.Register(new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m)));
        Assert.False(authenticator.IsRegistered(new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.8m))));
    }

    [Fact]
    [Task(5)]
    public void AreSameObject_same_objects()
    {
        var identityA = new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m));
        Assert.True(Authenticator.AreSameObject(identityA, identityA));
    }

    [Fact]
    [Task(5)]
    public void AreSameObject_different_objects()
    {
        var identityA = new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m));
        var identityB = new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m));
        Assert.False(Authenticator.AreSameObject(identityA, identityB));
    }

}

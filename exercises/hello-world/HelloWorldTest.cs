using Xunit;

public class HelloWorldTest
{
    [Fact]
    public void No_name()
    {
        Assert.Equal("Hello, World!", HelloWorld.Hello(null));
    }

    [Fact(Skip="Remove to run test")]
    public void Sample_name()
    {
        Assert.Equal("Hello, Alice!", HelloWorld.Hello("Alice"));
    }

    [Fact(Skip="Remove to run test")]
    public void Other_sample_name()
    {
        Assert.Equal("Hello, Bob!", HelloWorld.Hello("Bob"));
    }
}

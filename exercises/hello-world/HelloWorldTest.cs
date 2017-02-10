using Xunit;

public class HelloWorldTest
{
    [Fact]
    public void No_name()
    {
        Assert.Equal("Hello, World!", HelloWorld.Hello(null));
    }

    [Fact]
    public void Sample_name()
    {
        Assert.Equal("Hello, Alice!", HelloWorld.Hello("Alice"));
    }

    [Fact]
    public void Other_sample_name()
    {
        Assert.Equal("Hello, Bob!", HelloWorld.Hello("Bob"));
    }
}

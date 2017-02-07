using Xunit;

public class HelloWorldTest
{
    [Fact]
    public void No_name()
    {
        Assert.That(HelloWorld.Hello(null), Is.EqualTo("Hello, World!"));
    }

    [Fact(Skip="Remove to run test")]
    public void Sample_name()
    {
        Assert.That(HelloWorld.Hello("Alice"), Is.EqualTo("Hello, Alice!"));
    }

    [Fact(Skip="Remove to run test")]
    public void Other_sample_name()
    {
        Assert.That(HelloWorld.Hello("Bob"), Is.EqualTo("Hello, Bob!"));
    }
}

using Xunit;

public class HelloWorldTest
{
    [Fact]
    public void Say_hi()
    {
        Assert.Equal("Hello, World!", HelloWorld.Hello());
    }
}

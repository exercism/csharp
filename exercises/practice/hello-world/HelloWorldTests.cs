public class HelloWorldTests
{
    [Fact]
    public void Say_hi()
    {
        Assert.Equal("Hello, World!", HelloWorld.Hello());
    }
}

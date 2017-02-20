using NUnit.Framework;

[TestFixture]
public class HelloWorldTest
{
    [Test]
    public void Say_hi()
    {
        Assert.That(HelloWorld.Hello(), Is.EqualTo("Hello, World!"));
    }
}

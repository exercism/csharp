using Xunit;

public class TwoFerTests
{
    [Fact]
    public void NoNameGiven()
    {
        Assert.Equal("One for you, one for me.", TwoFer.Speak());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ANameGiven()
    {
        Assert.Equal("One for Alice, one for me.", TwoFer.Speak("Alice"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void AnotherNameGiven()
    {
        Assert.Equal("One for Bob, one for me.", TwoFer.Speak("Bob"));
    }
}

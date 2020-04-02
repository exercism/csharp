// This file was auto-generated based on version 1.2.0 of the canonical data.

using Xunit;

public class TwoFerTests
{
    [Fact]
    public void No_name_given()
    {
        Assert.Equal("One for you, one for me.", TwoFer.Speak());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_name_given()
    {
        Assert.Equal("One for Alice, one for me.", TwoFer.Speak("Alice"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Another_name_given()
    {
        Assert.Equal("One for Bob, one for me.", TwoFer.Speak("Bob"));
    }
}
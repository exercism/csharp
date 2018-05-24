// This file was auto-generated based on version 1.2.0 of the canonical data.

using Xunit;

public class TwoFerTest
{
    [Fact]
    public void No_name_given()
    {
        Assert.Equal("One for you, one for me.", TwoFer.Name());
    }

    [Fact(Skip = "Remove to run test")]
    public void A_name_given()
    {
        Assert.Equal("One for Alice, one for me.", TwoFer.Name("Alice"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Another_name_given()
    {
        Assert.Equal("One for Bob, one for me.", TwoFer.Name("Bob"));
    }
}
using Xunit;

public class LuhnTest
{
    [Theory]
    [InlineData("1", false)] // single digit strings can not be valid
    [InlineData("0", false)] // a single zero is invalid
    [InlineData("046 454 286", true)] // valid Canadian SIN
    [InlineData("046 454 287", false)] // invalid Canadian SIN
    [InlineData("8273 1232 7352 0569", false)] // invalid credit card
    [InlineData("827a 1232 7352 0569", false)] // strings that contain non-digits are not valid
    public void ValidateChecksum(string number, bool expected)
    {
        Assert.Equal(expected, Luhn.IsValid(number));
    }
}
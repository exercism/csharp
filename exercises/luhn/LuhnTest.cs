using NUnit.Framework;

[TestFixture]
public class LuhnTest
{
    [TestCase("1", ExpectedResult = false)] // single digit strings can not be valid
    [TestCase("0", ExpectedResult = false, Ignore = "Remove to run test")] // a single zero is invalid
    [TestCase("046 454 286", ExpectedResult = true, Ignore = "Remove to run test")] // valid Canadian SIN
    [TestCase("046 454 287", ExpectedResult = false, Ignore = "Remove to run test")] // invalid Canadian SIN
    [TestCase("8273 1232 7352 0569", ExpectedResult = false, Ignore = "Remove to run test")] // invalid credit card
    [TestCase("827a 1232 7352 0569", ExpectedResult = false, Ignore = "Remove to run test")] // strings that contain non-digits are not valid
    public bool ValidateChecksum(string number)
    {
        return Luhn.IsValid(number);
    }
}
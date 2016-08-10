using NUnit.Framework;

[TestFixture]
public class RomanNumeralsTest
{
    [TestCase(0, ExpectedResult = "")]
    [TestCase(1, ExpectedResult = "I", Ignore = "Remove to run test case")]
    [TestCase(2, ExpectedResult = "II", Ignore = "Remove to run test case")]
    [TestCase(3, ExpectedResult = "III", Ignore = "Remove to run test case")]
    [TestCase(4, ExpectedResult = "IV", Ignore = "Remove to run test case")]
    [TestCase(5, ExpectedResult = "V", Ignore = "Remove to run test case")]
    [TestCase(6, ExpectedResult = "VI", Ignore = "Remove to run test case")]
    [TestCase(9, ExpectedResult = "IX", Ignore = "Remove to run test case")]
    [TestCase(27, ExpectedResult = "XXVII", Ignore = "Remove to run test case")]
    [TestCase(48, ExpectedResult = "XLVIII", Ignore = "Remove to run test case")]
    [TestCase(59, ExpectedResult = "LIX", Ignore = "Remove to run test case")]
    [TestCase(93, ExpectedResult = "XCIII", Ignore = "Remove to run test case")]
    [TestCase(141, ExpectedResult = "CXLI", Ignore = "Remove to run test case")]
    [TestCase(163, ExpectedResult = "CLXIII", Ignore = "Remove to run test case")]
    [TestCase(402, ExpectedResult = "CDII", Ignore = "Remove to run test case")]
    [TestCase(575, ExpectedResult = "DLXXV", Ignore = "Remove to run test case")]
    [TestCase(911, ExpectedResult = "CMXI", Ignore = "Remove to run test case")]
    [TestCase(1024, ExpectedResult = "MXXIV", Ignore = "Remove to run test case")]
    [TestCase(3000, ExpectedResult = "MMM", Ignore = "Remove to run test case")]
    public string Convert_roman_to_arabic_numerals(int arabicNumeral)
    {
        return arabicNumeral.ToRoman();
    }
}
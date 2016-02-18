using NUnit.Framework;

public class NthPrimeTest
{
    [TestCase(1, ExpectedResult = 2)]
    [TestCase(2, ExpectedResult = 3, Ignore = "Remove to run test case")]
    [TestCase(3, ExpectedResult = 5, Ignore = "Remove to run test case")]
    [TestCase(4, ExpectedResult = 7, Ignore = "Remove to run test case")]
    [TestCase(5, ExpectedResult = 11, Ignore = "Remove to run test case")]
    [TestCase(6, ExpectedResult = 13, Ignore = "Remove to run test case")]
    [TestCase(7, ExpectedResult = 17, Ignore = "Remove to run test case")]
    [TestCase(8, ExpectedResult = 19, Ignore = "Remove to run test case")]
    [TestCase(1000, ExpectedResult = 7919, Ignore = "Remove to run test case")]
    [TestCase(10000, ExpectedResult = 104729, Ignore = "Remove to run test case")]
    [TestCase(10001, ExpectedResult = 104743, Ignore = "Remove to run test case")]
    public int Nth_prime_calculated(int nth)
    {
        return NthPrime.Nth(nth);
    }
}
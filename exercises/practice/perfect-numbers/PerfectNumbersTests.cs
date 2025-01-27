using Xunit;

public class PerfectNumbersTests
{
    [Fact]
    public void PerfectNumbersSmallestPerfectNumberIsClassifiedCorrectly()
    {
        Assert.Equal(Classification.Perfect, PerfectNumbers.Classify(6));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void PerfectNumbersMediumPerfectNumberIsClassifiedCorrectly()
    {
        Assert.Equal(Classification.Perfect, PerfectNumbers.Classify(28));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void PerfectNumbersLargePerfectNumberIsClassifiedCorrectly()
    {
        Assert.Equal(Classification.Perfect, PerfectNumbers.Classify(33550336));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void AbundantNumbersSmallestAbundantNumberIsClassifiedCorrectly()
    {
        Assert.Equal(Classification.Abundant, PerfectNumbers.Classify(12));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void AbundantNumbersMediumAbundantNumberIsClassifiedCorrectly()
    {
        Assert.Equal(Classification.Abundant, PerfectNumbers.Classify(30));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void AbundantNumbersLargeAbundantNumberIsClassifiedCorrectly()
    {
        Assert.Equal(Classification.Abundant, PerfectNumbers.Classify(33550335));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DeficientNumbersSmallestPrimeDeficientNumberIsClassifiedCorrectly()
    {
        Assert.Equal(Classification.Deficient, PerfectNumbers.Classify(2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DeficientNumbersSmallestNonPrimeDeficientNumberIsClassifiedCorrectly()
    {
        Assert.Equal(Classification.Deficient, PerfectNumbers.Classify(4));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DeficientNumbersMediumDeficientNumberIsClassifiedCorrectly()
    {
        Assert.Equal(Classification.Deficient, PerfectNumbers.Classify(32));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DeficientNumbersLargeDeficientNumberIsClassifiedCorrectly()
    {
        Assert.Equal(Classification.Deficient, PerfectNumbers.Classify(33550337));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DeficientNumbersEdgeCaseNoFactorsOtherThanItselfIsClassifiedCorrectly()
    {
        Assert.Equal(Classification.Deficient, PerfectNumbers.Classify(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void InvalidInputsZeroIsRejectedAsItIsNotAPositiveInteger()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => PerfectNumbers.Classify(0));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void InvalidInputsNegativeIntegerIsRejectedAsItIsNotAPositiveInteger()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => PerfectNumbers.Classify(-1));
    }
}

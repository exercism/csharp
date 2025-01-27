using Xunit;

public class SumOfMultiplesTests
{
    [Fact]
    public void NoMultiplesWithinLimit()
    {
        Assert.Equal(0, SumOfMultiples.Sum([3, 5], 1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void OneFactorHasMultiplesWithinLimit()
    {
        Assert.Equal(3, SumOfMultiples.Sum([3, 5], 4));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void MoreThanOneMultipleWithinLimit()
    {
        Assert.Equal(9, SumOfMultiples.Sum([3], 7));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void MoreThanOneFactorWithMultiplesWithinLimit()
    {
        Assert.Equal(23, SumOfMultiples.Sum([3, 5], 10));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void EachMultipleIsOnlyCountedOnce()
    {
        Assert.Equal(2318, SumOfMultiples.Sum([3, 5], 100));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void AMuchLargerLimit()
    {
        Assert.Equal(233168, SumOfMultiples.Sum([3, 5], 1000));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ThreeFactors()
    {
        Assert.Equal(51, SumOfMultiples.Sum([7, 13, 17], 20));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void FactorsNotRelativelyPrime()
    {
        Assert.Equal(30, SumOfMultiples.Sum([4, 6], 15));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void SomePairsOfFactorsRelativelyPrimeAndSomeNot()
    {
        Assert.Equal(4419, SumOfMultiples.Sum([5, 6, 8], 150));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void OneFactorIsAMultipleOfAnother()
    {
        Assert.Equal(275, SumOfMultiples.Sum([5, 25], 51));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void MuchLargerFactors()
    {
        Assert.Equal(2203160, SumOfMultiples.Sum([43, 47], 10000));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void AllNumbersAreMultiplesOf1()
    {
        Assert.Equal(4950, SumOfMultiples.Sum([1], 100));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void NoFactorsMeansAnEmptySum()
    {
        Assert.Equal(0, SumOfMultiples.Sum([], 10000));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TheOnlyMultipleOf0Is0()
    {
        Assert.Equal(0, SumOfMultiples.Sum([0], 1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TheFactor0DoesNotAffectTheSumOfMultiplesOfOtherFactors()
    {
        Assert.Equal(3, SumOfMultiples.Sum([3, 0], 4));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void SolutionsUsingIncludeExcludeMustExtendToCardinalityGreaterThan3()
    {
        Assert.Equal(39614537, SumOfMultiples.Sum([2, 3, 5, 7, 11], 10000));
    }
}

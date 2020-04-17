using Xunit;

public class SavingsAccountTests
{
    [Fact]
    public void MinimalFirstInterestRate()
    {
        Assert.Equal(0.5f, SavingsAccount.InterestRate(0m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TinyFirstInterestRate()
    {
        Assert.Equal(0.5f, SavingsAccount.InterestRate(0.000001m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void MaximumFirstInterestRate()
    {
        Assert.Equal(0.5f, SavingsAccount.InterestRate(999.9999m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void MinimalSecondInterestRate()
    {
        Assert.Equal(1.621f, SavingsAccount.InterestRate(1_000.0m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TinySecondInterestRate()
    {
        Assert.Equal(1.621f, SavingsAccount.InterestRate(1_000.0001m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void MaximumSecondInterestRate()
    {
        Assert.Equal(1.621f, SavingsAccount.InterestRate(4_999.9990m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void MinimalThirdInterestRate()
    {
        Assert.Equal(2.475f, SavingsAccount.InterestRate(5_000.0000m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TinyThirdInterestRate()
    {
        Assert.Equal(2.475f, SavingsAccount.InterestRate(5_000.0001m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void LargeThirdInterestRate()
    {
        Assert.Equal(2.475f, SavingsAccount.InterestRate(5_639_998.742909m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void MinimalNegativeInterestRate()
    {
        Assert.Equal(-3.213f, SavingsAccount.InterestRate(-0.000001m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void SmallNegativeInterestRate()
    {
        Assert.Equal(-3.213f, SavingsAccount.InterestRate(-0.123m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RegularNegativeInterestRate()
    {
        Assert.Equal(-3.213f, SavingsAccount.InterestRate(-300.0m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void LargeNegativeInterestRate()
    {
        Assert.Equal(-3.213f, SavingsAccount.InterestRate(-152964.231m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void AnnualBalanceUpdateForEmptyStartBalance()
    {
        Assert.Equal(0.0000m, SavingsAccount.AnnualBalanceUpdate(0.0m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void AnnualBalanceUpdateForSmallPositiveStartBalance()
    {
        Assert.Equal(0.000001005m, SavingsAccount.AnnualBalanceUpdate(0.000001m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void AnnualBalanceUpdateForAveragePositiveStartBalance()
    {
        Assert.Equal(1016.210000m, SavingsAccount.AnnualBalanceUpdate(1_000.0m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void AnnualBalanceUpdateForLargePositiveStartBalance()
    {
        Assert.Equal(1016.210101621m, SavingsAccount.AnnualBalanceUpdate(1_000.0001m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void AnnualBalanceUpdateForHugePositiveStartBalance()
    {
        Assert.Equal(920352587.26744292868451875m, SavingsAccount.AnnualBalanceUpdate(898124017.826243404425m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void AnnualBalanceUpdateForSmallNegativeStartBalance()
    {
        Assert.Equal(-0.12695199m, SavingsAccount.AnnualBalanceUpdate(-0.123m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void AnnualBalanceUpdateForLargeNegativeStartBalance()
    {
        Assert.Equal(-157878.97174203m, SavingsAccount.AnnualBalanceUpdate(-152964.231m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void YearsBeforeDesiredBalanceForSmallStartBalance()
    {
        Assert.Equal(47, SavingsAccount.YearsBeforeDesiredBalance(100.0m, 125.80m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void YearsBeforeDesiredBalanceForAverageStartBalance()
    {
        Assert.Equal(6, SavingsAccount.YearsBeforeDesiredBalance(1_000.0m, 1_100.0m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void YearsBeforeDesiredBalanceForLargeStartBalance()
    {
        Assert.Equal(5, SavingsAccount.YearsBeforeDesiredBalance(8_080.80m, 9_090.90m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void YearsBeforeDesiredBalanceForLargeDifferentBetweenStartAndTargetBalance()
    {
        Assert.Equal(85, SavingsAccount.YearsBeforeDesiredBalance(2_345.67m, 12_345.6789m));
    }
}

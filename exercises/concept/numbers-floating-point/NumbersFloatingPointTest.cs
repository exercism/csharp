using Xunit;

public class SavingsAccountTest
{
    [Fact]
    public void MinimalFirstAnnualPercentageYield() =>
        Assert.Equal(0.5f, SavingsAccount.AnnualPercentageYield(0m));

    [Fact]
    public void TinyFirstAnnualPercentageYield() =>
        Assert.Equal(0.5f, SavingsAccount.AnnualPercentageYield(0.000001m));

    [Fact]
    public void MaximumFirstAnnualPercentageYield() =>
        Assert.Equal(0.5f, SavingsAccount.AnnualPercentageYield(999.9999m));

    [Fact]
    public void MinimalSecondAnnualPercentageYield() =>
        Assert.Equal(1.621f, SavingsAccount.AnnualPercentageYield(1_000.0m));

    [Fact]
    public void TinySecondAnnualPercentageYield() =>
        Assert.Equal(1.621f, SavingsAccount.AnnualPercentageYield(1_000.0001m));

    [Fact]
    public void MaximumSecondAnnualPercentageYield() =>
        Assert.Equal(1.621f, SavingsAccount.AnnualPercentageYield(4_999.9990m));

    [Fact]
    public void MinimalThirdAnnualPercentageYield() =>
        Assert.Equal(2.475f, SavingsAccount.AnnualPercentageYield(5_000.0000m));

    [Fact]
    public void TinyThirdAnnualPercentageYield() =>
        Assert.Equal(2.475f, SavingsAccount.AnnualPercentageYield(5_000.0001m));

    [Fact]
    public void LargeThirdAnnualPercentageYield() =>
        Assert.Equal(2.475f, SavingsAccount.AnnualPercentageYield(5_639_998.742909m));

    [Fact]
    public void MinimalNegativeAnnualPercentageYield() =>
        Assert.Equal(-3.213f, SavingsAccount.AnnualPercentageYield(-0.000001m));

    [Fact]
    public void SmallNegativeAnnualPercentageYield() =>
        Assert.Equal(-3.213f, SavingsAccount.AnnualPercentageYield(-0.123m));

    [Fact]
    public void RegularNegativeAnnualPercentageYield() =>
        Assert.Equal(-3.213f, SavingsAccount.AnnualPercentageYield(-300.0m));

    [Fact]
    public void LargeNegativeAnnualPercentageYield() =>
        Assert.Equal(-3.213f, SavingsAccount.AnnualPercentageYield(-152964.231m));

    [Fact]
    public void AnnualBalanceUpdateForEmptyStartBalance() =>
        Assert.Equal(0.0000m, SavingsAccount.AnnualBalanceUpdate(0.0m));

    [Fact]
    public void AnnualBalanceUpdateForSmallPositiveStartBalance() =>
        Assert.Equal(0.000001005m, SavingsAccount.AnnualBalanceUpdate(0.000001m));

    [Fact]
    public void AnnualBalanceUpdateForAveragePositiveStartBalance() =>
        Assert.Equal(1016.210000m, SavingsAccount.AnnualBalanceUpdate(1_000.0m));

    [Fact]
    public void AnnualBalanceUpdateForLargePositiveStartBalance() =>
        Assert.Equal(1016.210101621m, SavingsAccount.AnnualBalanceUpdate(1_000.0001m));

    [Fact]
    public void AnnualBalanceUpdateForHugePositiveStartBalance() =>
        Assert.Equal(920352587.26744292868451875m, SavingsAccount.AnnualBalanceUpdate(898124017.826243404425m));

    [Fact]
    public void AnnualBalanceUpdateForSmallNegativeStartBalance() =>
        Assert.Equal(-0.12695199m, SavingsAccount.AnnualBalanceUpdate(-0.123m));

    [Fact]
    public void AnnualBalanceUpdateForLargeNegativeStartBalance() =>
        Assert.Equal(-157878.97174203m, SavingsAccount.AnnualBalanceUpdate(-152964.231m));

    [Fact]
    public void YearsBeforeDesiredBalanceForSmallStartBalance() =>
        Assert.Equal(47, SavingsAccount.YearsBeforeDesiredBalance(100.0m, 125.80m));

    [Fact]
    public void YearsBeforeDesiredBalanceForAverageStartBalance() =>
        Assert.Equal(6, SavingsAccount.YearsBeforeDesiredBalance(1_000.0m, 1_100.0m));

    [Fact]
    public void YearsBeforeDesiredBalanceForLargeStartBalance() =>
        Assert.Equal(5, SavingsAccount.YearsBeforeDesiredBalance(8_080.80m, 9_090.90m));

    [Fact]
    public void YearsBeforeDesiredBalanceForLargeDifferentBetweenStartAndTargetBalance() =>
        Assert.Equal(85, SavingsAccount.YearsBeforeDesiredBalance(2_345.67m, 12_345.6789m));
}
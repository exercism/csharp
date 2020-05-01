using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if (balance < 0.0m)
        {
            return -3.213f;
        }

        if (balance < 1000.0m)
        {
            return 0.5f;
        }

        if (balance < 5000.0m)
        {
            return 1.621f;
        }

        return 2.475f;
    }

    private static decimal AnnualYield(decimal balance)
    {
        var multiplier = (decimal)InterestRate(balance) / 100;
        return Math.Abs(balance) * multiplier;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + AnnualYield(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        var accumulatingBalance = balance;
        var years = 0;

        while (accumulatingBalance < targetBalance)
        {
            accumulatingBalance = AnnualBalanceUpdate(accumulatingBalance);
            years++;
        }

        return years;
    }
}

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

    public static decimal Interest(decimal balance)
    {
        return Math.Abs(balance) * ((decimal)InterestRate(balance) / 100);
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
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

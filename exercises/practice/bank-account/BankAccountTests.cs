using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class BankAccountTests
{
    [Fact]
    public void Returns_empty_balance_after_opening()
    {
        var account = new BankAccount();
        account.Open();

        Assert.Equal(0m, account.Balance);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Check_basic_balance()
    {
        var account = new BankAccount();
        account.Open();

        var openingBalance = account.Balance;

        account.UpdateBalance(10m);
        var updatedBalance = account.Balance;

        Assert.Equal(0m, openingBalance);
        Assert.Equal(10m, updatedBalance);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Balance_can_increment_and_decrement()
    {
        var account = new BankAccount();
        account.Open();
        var openingBalance = account.Balance;

        account.UpdateBalance(10m);
        var addedBalance = account.Balance;

        account.UpdateBalance(-15m);
        var subtractedBalance = account.Balance;

        Assert.Equal(0m, openingBalance);
        Assert.Equal(10m, addedBalance);
        Assert.Equal(-5m, subtractedBalance);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Closed_account_throws_exception_when_checking_balance()
    {
        var account = new BankAccount();
        account.Open();
        account.Close();

        Assert.Throws<InvalidOperationException>(() => account.Balance);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Change_account_balance_from_multiple_threads()
    {
        var account = new BankAccount();
        var tasks = new List<Task>();

        var threads = 500;
        var iterations = 100;

        account.Open();
        for (int i = 0; i < threads; i++)
        {
            tasks.Add(Task.Factory.StartNew(() =>
            {
                for (int j = 0; j < iterations; j++)
                {
                    account.UpdateBalance(1m);
                    account.UpdateBalance(-1m);
                }
            }));
        }
        Task.WaitAll(tasks.ToArray());

        Assert.Equal(0m, account.Balance);
    }
}

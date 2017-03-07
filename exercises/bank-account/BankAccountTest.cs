using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class BankAccountTest
{
    [Fact]
    public void Returns_empty_balance_after_opening()
    {
        var account = new BankAccount();
        account.Open();

        Assert.Equal(0, account.Balance);
    }

    [Fact(Skip = "Remove to run test")]
    public void Check_basic_balance()
    {
        var account = new BankAccount();
        account.Open();

        var openingBalance = account.Balance;

        account.UpdateBalance(10);
        var updatedBalance = account.Balance;

        Assert.Equal(0, openingBalance);
        Assert.Equal(10, updatedBalance);
    }

    [Fact(Skip = "Remove to run test")]
    public void Balance_can_increment_and_decrement()
    {
        var account = new BankAccount();
        account.Open();
        var openingBalance = account.Balance;

        account.UpdateBalance(10);
        var addedBalance = account.Balance;

        account.UpdateBalance(-15);
        var subtractedBalance = account.Balance;

        Assert.Equal(0, openingBalance);
        Assert.Equal(10, addedBalance);
        Assert.Equal(-5, subtractedBalance);
    }

    [Fact(Skip = "Remove to run test")]
    public void Closed_account_throws_exception_when_checking_balance()
    {
        var account = new BankAccount();
        account.Open();
        account.Close();

        Assert.Throws<InvalidOperationException>(() => account.Balance);
    }

    [Fact(Skip = "Remove to run test")]
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
                    account.UpdateBalance(1);
                    account.UpdateBalance(-1);
                }
            }));
        }
        Task.WaitAll(tasks.ToArray());

        Assert.Equal(0, account.Balance);
    }
}

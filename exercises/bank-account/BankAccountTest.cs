using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

public class BankAccountTest
{
    [Test]
    public void Returns_empty_balance_after_opening()
    {
        var account = new BankAccount();
        account.Open();

        Assert.That(account.Balance, Is.EqualTo(0));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Check_basic_balance()
    {
        var account = new BankAccount();
        account.Open();

        var openingBalance = account.Balance;

        account.UpdateBalance(10);
        var updatedBalance = account.Balance;

        Assert.That(openingBalance, Is.EqualTo(0));
        Assert.That(updatedBalance, Is.EqualTo(10));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Balance_can_increment_and_decrement()
    {
        var account = new BankAccount();
        account.Open();
        var openingBalance = account.Balance;

        account.UpdateBalance(10);
        var addedBalance = account.Balance;

        account.UpdateBalance(-15);
        var subtractedBalance = account.Balance;

        Assert.That(openingBalance, Is.EqualTo(0));
        Assert.That(addedBalance, Is.EqualTo(10));
        Assert.That(subtractedBalance, Is.EqualTo(-5));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Closed_account_throws_exception_when_checking_balance()
    {
        var account = new BankAccount();
        account.Open();
        account.Close();

        Assert.That(() => account.Balance, Throws.InvalidOperationException);
    }

    [Ignore("Remove to run test")]
    [Test]
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

        Assert.That(account.Balance, Is.EqualTo(0));
    }
}

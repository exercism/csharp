using System;
using NUnit.Framework;

public class BankAccountTest
{
    [Test]
    public void Returns_empty_balance_after_opening()
    {
        var account = new BankAccount();
        account.Open();

        Assert.That(account.GetBalance(), Is.EqualTo(0));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Check_basic_balance()
    {
        var account = new BankAccount();
        account.Open();

        var openingBalance = account.GetBalance();

        account.UpdateBalance(10);
        var updatedBalance = account.GetBalance();

        Assert.That(openingBalance, Is.EqualTo(0));
        Assert.That(updatedBalance, Is.EqualTo(10));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Balance_can_increment_and_decrement()
    {
        var account = new BankAccount();
        account.Open();
        var openingBalance = account.GetBalance();

        account.UpdateBalance(10);
        var addedBalance = account.GetBalance();

        account.UpdateBalance(-15);
        var subtractedBalance = account.GetBalance();

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

        Assert.Throws<InvalidOperationException>(() => account.GetBalance());
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class BankAccountTests
{
    [Fact]
    public void Newly_opened_account_has_zero_balance()
    {
        var account = new BankAccount();
        account.Open();
        Assert.Equal(0m, account.Balance);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Single_deposit()
    {
        var account = new BankAccount();
        account.Open();
        account.Deposit(100m);
        Assert.Equal(100m, account.Balance);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiple_deposits()
    {
        var account = new BankAccount();
        account.Open();
        account.Deposit(100m);
        account.Deposit(50m);
        Assert.Equal(150m, account.Balance);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Withdraw_once()
    {
        var account = new BankAccount();
        account.Open();
        account.Deposit(100m);
        account.Withdraw(75m);
        Assert.Equal(25m, account.Balance);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Withdraw_twice()
    {
        var account = new BankAccount();
        account.Open();
        account.Deposit(100m);
        account.Withdraw(80m);
        account.Withdraw(20m);
        Assert.Equal(0m, account.Balance);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_do_multiple_operations_sequentially()
    {
        var account = new BankAccount();
        account.Open();
        account.Deposit(100m);
        account.Deposit(110m);
        account.Withdraw(200m);
        account.Deposit(60m);
        account.Withdraw(50m);
        Assert.Equal(20m, account.Balance);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cannot_check_balance_of_closed_account()
    {
        var account = new BankAccount();
        account.Open();
        account.Close();
        Assert.Throws<InvalidOperationException>(() => account.Balance);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cannot_deposit_into_closed_account()
    {
        var account = new BankAccount();
        account.Open();
        account.Close();
        Assert.Throws<InvalidOperationException>(() => account.Deposit(50m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cannot_deposit_into_unopened_account()
    {
        var account = new BankAccount();
        Assert.Throws<InvalidOperationException>(() => account.Deposit(50m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cannot_withdraw_from_closed_account()
    {
        var account = new BankAccount();
        account.Open();
        account.Close();
        Assert.Throws<InvalidOperationException>(() => account.Withdraw(50m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cannot_close_an_account_that_was_not_opened()
    {
        var account = new BankAccount();
        Assert.Throws<InvalidOperationException>(() => account.Close());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cannot_open_an_already_opened_account()
    {
        var account = new BankAccount();
        account.Open();
        Assert.Throws<InvalidOperationException>(() => account.Open());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reopened_account_does_not_retain_balance()
    {
        var account = new BankAccount();
        account.Open();
        account.Deposit(50m);
        account.Close();
        account.Open();
        Assert.Equal(0m, account.Balance);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cannot_withdraw_more_than_deposited()
    {
        var account = new BankAccount();
        account.Open();
        account.Deposit(25m);
        Assert.Throws<InvalidOperationException>(() => account.Withdraw(50m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cannot_withdraw_negative()
    {
        var account = new BankAccount();
        account.Open();
        account.Deposit(100m);
        Assert.Throws<InvalidOperationException>(() => account.Withdraw(-50m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cannot_deposit_negative()
    {
        var account = new BankAccount();
        account.Open();
        Assert.Throws<InvalidOperationException>(() => account.Deposit(-50m));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_handle_concurrent_transactions()
    {
        var account = new BankAccount();
        account.Open();
        for (int i = 0; i < 500; i++)
        {
            var tasks = new List<Task>();
            tasks.Add(Task.Factory.StartNew(() =>
            {
                for (int j = 0; j < 100; j++)
                {
                    account.Deposit(1m);
                    account.Withdraw(1m);
                }
            }));
            Task.WaitAll(tasks.ToArray());
        }
        Assert.Equal(0m, account.Balance);
    }
}

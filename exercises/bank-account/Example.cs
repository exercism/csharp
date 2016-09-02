using System;

public class BankAccount
{
    private float balance;
    private bool isOpen;

    public void Open()
    {
        isOpen = true;
    }

    public void Close()
    {
        isOpen = false;
    }

    public float GetBalance()
    {
        if (!isOpen)
        {
            throw new InvalidOperationException("Cannot get balance on an account that isn't open");
        }

        return balance;
    }

    public void UpdateBalance(float change)
    {
        if (!isOpen)
        {
            throw new InvalidOperationException("Cannot update balance on an account that isn't open");
        }

        balance += change;
    }
}
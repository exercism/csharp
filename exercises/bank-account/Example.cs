using System;

public class BankAccount
{
    private readonly object _lock = new object();

    private float balance;
    private bool isOpen;

    public void Open()
    {
        lock(_lock)
        {
            isOpen = true;
        }
    }

    public void Close()
    {
        lock(_lock)
        {
            isOpen = false;
        }
    }

    public float Balance
    {
        get
        {
            lock (_lock)
            {
                if (!isOpen)
                {
                    throw new InvalidOperationException("Cannot get balance on an account that isn't open");
                }

                return balance;
            }
        }
    }

    public void UpdateBalance(float change)
    {
        lock(_lock)
        {
            if (!isOpen)
            {
                throw new InvalidOperationException("Cannot update balance on an account that isn't open");
            }

            balance += change;
        }
    }
}

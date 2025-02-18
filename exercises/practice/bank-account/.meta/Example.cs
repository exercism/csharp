public class BankAccount
{
    private readonly object _lock = new object();

    private decimal balance;
    private bool isOpen;

    public void Open()
    {
        if (isOpen)
        {
            throw new InvalidOperationException("Cannot open an account that is already open");
        }

        lock(_lock)
        {
            isOpen = true;
        }
    }

    public void Close()
    {
        if (!isOpen)
        {
            throw new InvalidOperationException("Cannot close an account that isn't open");
        }

        lock(_lock)
        {
            isOpen = false;
            balance = 0;
        }
    }

    public decimal Balance
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

    public void Deposit(decimal change)
    {
        if (change < 0)
        {
            throw new InvalidOperationException("Cannot deposit a negative amount");
        }

        lock(_lock)
        {
            if (!isOpen)
            {
                throw new InvalidOperationException("Cannot deposit in account that isn't open");
            }

            balance += change;
        }
    }

    public void Withdraw(decimal change)
    {
        if (change < 0)
        {
            throw new InvalidOperationException("Cannot deposit a negative amount");
        }

        lock(_lock)
        {
            if (!isOpen)
            {
                throw new InvalidOperationException("Cannot withdraw from account that isn't open");
            }

            if (balance < change)
            {
                throw new InvalidOperationException("Cannot withdraw more than the balance");
            }

            balance -= change;
        }
    }
}

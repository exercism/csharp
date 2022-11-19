# `Mutex`

```csharp
using System;
using System.Threading;

public class BankAccount
{
    private readonly Mutex _mutex = new();

    private decimal _balance;
    private bool _isOpen;

    public void Open() => _isOpen = true;

    public void Close() => _isOpen = false;

    public decimal Balance => _isOpen ? _balance : throw new InvalidOperationException();

    public void UpdateBalance(decimal change)
    {
        if (!_isOpen)
            throw new InvalidOperationException("Account is closed");

        _mutex.WaitOne();

        try
        {
            _balance += change;
        }
        finally
        {
            _mutex.ReleaseMutex();
        }
    }
}
```

First, we define to field to keep track of our account's balance and whether the account is opened or closed:

```csharp
private decimal _balance;
private bool _isOpen;
```

```exercism/caution
When dealing with monetary amount, _always_ use `decimal` instead of `float` or `double`, as the later suffer from rounding errors.
```

The `Open()` and `Close()` methods change the open state:

```csharp
public void Open()
{
    _isOpen = true;
}

public void Close()
{
    _isOpen = false;
}
```

The `Balance` property either returns the current balance if the account has been opened, or throws an `InvalidOperationException` if not:

```csharp
public decimal Balance
{
    get
    {
        if (!_isOpen)
            throw new InvalidOperationException("Account is closed");

        return _balance;
    }
}
```

We then get to the core of the exercise: updating the balance in a safe way, without any concurrency issues.
First, we check if the account is not actually closed, in which case we throw an `InvalidOperationException`:

```csharp
public void UpdateBalance(decimal change)
{
    if (!_isOpen)
        throw new InvalidOperationException("Account is closed");

    ...
}
```

For that, we can use the [`Mutex`class][mutex], which allows programmatically restricting access to a section of code.
This ensures that there is never any concurrent execution of the code within the mutex's restricted scope.
Any other process wanting to execute the same code is halted until the currently executing process is done executing the mutex's code block.

Let's define an instance of the `Mutex` class::

```csharp
private readonly Mutex _mutex = new Mutex();
```

We can then use the `Mutex` to signal that we want to acquire exclusive access by using its `WaitOne()` method.
This method will block until there it has been released by any other process that has acquired the mutex.

```csharp
_mutex.WaitOne();
_balance += change;
_mutex.ReleaseMutex();
```

We can then safely update the balance and finish off by releasing the mutex.

As our `Mutex` object is unique per instance of the `BankAccount` class, we won't have any issues with locking other bank accounts when we use the mutex.
One potential issue we currently have is that the mutex is not released if the balance updating somehow throw an exception.
To fix this, we'll release the mutex in a `try/finally` statement:

```csharp
try
{
    _balance += change;
}
finally
{
    _mutex.ReleaseMutex();
}
```

## Shortening

The `Open()` and `Close()` methods have just one single statement and thus can be written as [expression-bodied methods][expression-bodied-members]:

```csharp
public void Open() => _isOpen = true;
public void Close() => _isOpen = false;
```

The same can be done for the `Balance` property, using the [ternary operator][ternary-operator] (`? :`):

```csharp
public decimal Balance => _isOpen ? _balance : throw new InvalidOperationException();
```

Finally, we can use a [target-typed new][target-typed-new] expression to replace `new object` with just `new` for creating the `Mutex`` (the compiler can figure out the type from the method's return type):

```csharp
private readonly object _mutex = new();
```

[expression-bodied-members]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
[ternary-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
[target-typed-new]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/target-typed-new
[lock-statement]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/lock
[mutex]: https://learn.microsoft.com/en-us/dotnet/api/system.threading.mutex

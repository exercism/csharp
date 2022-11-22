# Introduction

The key to this exercise is to make sure that the bank account can be updated concurrently without ending up in a state where the balance is incorrect.

## General guidance

- There are several ways to request exclusive access to a bit of code, including locks and mutexes.

## Approach: `lock` statement

```csharp
public class BankAccount
{
    private readonly object _lock = new();

    private decimal _balance;
    private bool _isOpen;

    public void Open() => _isOpen = true;
    public void Close() => _isOpen = false;

    public decimal Balance => _isOpen ? _balance : throw new InvalidOperationException();

    public void UpdateBalance(decimal change)
    {
        if (!_isOpen)
            throw new InvalidOperationException("Account is closed");

        lock (_lock)
            _balance += change;
    }
}
```

This approach uses a [`lock` statement][lock-statement] to prevent concurrent updates to the balance.
For more information, check the [`lock` statement approach][approach-lock-statement].

## Approach: `Mutex`

```csharp
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

This approach uses a [`Mutex`][mutex] to prevent concurrent updates to the balance.
For more information, check the [`Mutex` approach][approach-mutex].

## Lock-free programmaing

Whilst using locks (or mutexes) makes for simple code, they come at a small performance cost.
Lock-free programming aims to provide alternative means of safe concurrent updating.
One such mechanism is to use an atomic CPU instruction called [_compare and swap_][compare-and-swap].

```exercism/note
The compare and swap instruction takes three arguments: the address of the memory you want to update, its current value and the new value.
The memory will only be updated if the current value is equal to the provided value.
If this is not the case, some other code must have updated the value, so in that case it is not safe to update the value.
The instruction's return value indicates if the compare and swap exchange succeeded, and if not, you could retry with the newly updated value.
```

The .NET framework allows using this instruction via the [`Interlocked.CompareExchange()`][interlocked.compare-exchange] method.
Unfortunately, we can't use this to solve in this exercise, as the value that we want to update is a `decimal` and compare and swap is not supported for `decimal` values.
This is due to decimals required too much memory to be swapped atomically.

## Which approach to use?

While both approaches basically are almost identical, the `lock` version is more idiomatic.
They do offer different levels of concurrency guarantees though.

```exercism/caution
Locks offer protection against concurrent access via threads, but mutexes even offer protection against concurrent access via processes.
```

[approach-lock-statement]: https://exercism.org/tracks/csharp/exercises/bank-account/approaches/lock-statement
[approach-mutex]: https://exercism.org/tracks/csharp/exercises/bank-account/approaches/mutex
[lock-statement]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/lock
[mutex]: https://learn.microsoft.com/en-us/dotnet/api/system.threading.mutex
[interlocked.compare-exchange]: https://learn.microsoft.com/en-us/dotnet/api/system.threading.interlocked.compareexchange
[compare-and-swap]: https://en.wikipedia.org/wiki/Compare-and-swap

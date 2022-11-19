# `lock` statement

```csharp
using System;

public class BankAccount
{
    private readonly object _lock = new();

    private decimal _balance;
    private bool _isOpen;

    public void Open() => _isOpen = true;

    public void Close() => _isOpen = false;

    public decimal Balance => _isOpen ? _balance : throw new InvalidOperationException("Account is closed");

    public void UpdateBalance(decimal change)
    {
        if (!_isOpen)
            throw new InvalidOperationException("Account is closed");

        lock (_lock)
            _balance += change;
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

For that, we can use a [`lock` statement][lock-statement], which takes an object to lock on and ensures that there is never any concurrent execution of the code within the lock's scope.
Any other process wanting to execute the same code is halted until the currently executing process is done executing the lock's code block.

As said, you take a lock on an object.
It is good practice to define a separate field for that, of type `object`:

```csharp
private readonly object _lock = new object();
```

We can then lock on this object to safely update our balance:

```csharp
lock (_lock)
{
    _balance += change;
}
```

As our lock object is unique per instance of the `BankAccount` class, we won't have any issues with locking other bank accounts when we lock on that object.

````exercism/note
The `lock` statement is syntactic sugar for calls to `Monitor.Enter()` and `Monitor.Exit()`, using a `try/finally` block.

```csharp
lock (_lock)
{
    _balance += change;
}
```

gets compiled to:

```csharp
Monitor.Enter(_lock)
try
{
    _balance += change;
}
finally
{
    Monitor.Exit(_lock);
}
```
````

## Shortening

The `lock` statement has only one statement in its scope, so we can omit the braces:

```csharp
lock (_lock)
    _balance += change;
```

The `Open()` and `Close()` methods have just one single statement and thus can be written as [expression-bodied methods][expression-bodied-members]:

```csharp
public void Open() => _isOpen = true;
public void Close() => _isOpen = false;
```

The same can be done for the `Balance` property, using the [ternary operator][ternary-operator] (`? :`):

```csharp
public decimal Balance => _isOpen ? _balance : throw new InvalidOperationException();
```

Finally, we can use a [target-typed new][target-typed-new] expression to replace `new object` with just `new` for creating the lock (the compiler can figure out the type from the method's return type):

```csharp
private readonly object _lock = new();
```

[expression-bodied-members]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
[ternary-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
[target-typed-new]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/target-typed-new
[lock-statement]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/lock

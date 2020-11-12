An `if` statement can be used to conditionally execute code. The condition of an `if` statement must be of type `bool`. C# has no concept of _truthy_ values.

The most common way to do this in C# is by using [an `if/else` statement][if-else]:

```csharp
int x = 6;

if (x == 5)
{
    // Execute logic if x equals 5
}
else if (x > 7)
{
    // Execute logic if x greater than 7
}
else
{
    // Execute logic in all other cases
}
```

[if-else]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/if-else

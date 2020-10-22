An `if` statement can be used to conditionally execute code. The condition of an `if` statement must be of type `bool`. C# has no concept of _truthy_ values.

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

There are two different types of numbers in C#:

- Integers: numbers with no digits behind the decimal separator (whole numbers). Examples are `-6`, `0`, `1`, `25`, `976` and `500000`.
- Floating-point numbers: numbers with zero or more digits behind the decimal separator. Examples are `-2.4`, `0.1`, `3.14`, `16.984025` and `1024.0`.

The two most common numeric types in C# are `int` and `double`. An `int` is a 32-bit integer and a `double` is a 64-bit floating-point number.

Arithmetic is done using the standard arithmetic operators. Numbers can be compared using the standard numeric comparison operators and the equality (`==`) and inequality (`!=`) operators.

C# has two types of numeric conversions:

1. Implicit conversions: no data will be lost and no additional syntax is required.
2. Explicit conversions: data could be lost and additional syntax in the form of a _cast_ is required.

As an `int` has less precision than a `double`, converting from an `int` to a `double` is safe and is thus an implicit conversion. However, converting from a `double` to an `int` could mean losing data, so that requires an explicit conversion.

In this exercise you must conditionally execute logic. The most common way to do this in C# is by using an `if/else` statement:

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

The condition of an `if` statement must be of type `bool`. C# has no concept of _truthy_ values.

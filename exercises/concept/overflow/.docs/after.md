The exercise shows the behavior of various numeric types when they overflow, i.e. when their capacity is insufficient to contain the value resulting from a computation such as an arithmetic operation or cast.

- unsigned [integers][integral-numeric-types] (`byte`, `ushort`, `uint`, `ulong`) will wrap around to zero (the type's maximum value + 1 acts as a modulus) unless [broadly speaking][checked-compiler-setting] they appear within a [`checked`][checked-and-unchecked] block in which case an instance of `OverflowException` is thrown. `int` and `long` will behave similarly except that they wrap around to `int.MinValue` and `long.minValue` respectively.

```csharp
int one = 1;
checked
{
    int expr = int.MaxValue + one;  // overflow exception is thrown
}

// or

int expr2 = checked(int.MaxValue + one);  // overflow exception is thrown
```

- If a literal expression would cause the variable to which it is assigned to overflow then a compile-time error occurs.
- the `checked` state applies only to expressions directly in the block. Overflow states in called functions are not caught.
- [`float` and `double`][floating-point-numeric-types] types will adopt a state of _infinity_ that can be tested wtih `float.IsInfinity()` etc.

```csharp
double d = double.MaxValue;
d *= 2d;
Double.IsFinite(d)
// => false
```

- Numbers of type [`decimal`][floating-point-numeric-types] will cause an instance of `OverflowException` to be thrown.
- There is a corresponding `unchecked` keyword for circumstances where you want to reverse the effect of `unchecked` inside a `checked` block or when the compiler setting has been used.

Overflows that occur without an exception being thrown can be problematic because it's generally true that the earlier an error condition can be reported the better.

Problems with overflows for `int` and `float` can be mitigated by assigning the result to a variable of type `long`, `decimal` or `double`.

If large integers are essential to your code then using the [`BigInteger`][big-integer] type is an option.

Naturally there are occasions on which it is legitimate to allow an integer to wrap around particularly in the case of unsigned values. A classic case is that of hash codes that use the width of the integer as a kind of modulo.

You will usually find in code bases that there is often no check where an `uint` or a `ulong` is used as an identifier because it is considered more trouble than it's worth. This also applies where it is evident from the domain that no very large values will be involved. But, look at [this][computerphile-gangnam-style] for a cautionary tale.

- [Integral numeric types][integral-numeric-types]: overview of the integral numeric types.
- [Floating-point numeric types][floating-point-numeric-types]: overview of the floating-point numeric types.
- [Numeric conversions][numeric-conversions]: overview of implicit and explicit numeric conversions.
- [Checked and unchecked arithmetic][checked-and-unchecked]: introduction to overflows
- [`checked` keyword][checked-keyword]: `checked` keyword reference.
- [`unchecked` keyword][unchecked-keyword]: `unchecked` keyword reference.
- [Computerphile: How Gangnam Style broke YouTube][computerphile-gangnam-style]

[computerphile-gangnam-style]: https://www.youtube.com/watch?v=vA0Rl6Ne5C8
[integral-numeric-types]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
[floating-point-numeric-types]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types
[numeric-conversions]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions
[checked-and-unchecked]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/checked-and-unchecked
[checked-keyword]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/checked
[unchecked-keyword]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/unchecked
[checked-compiler-setting]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-options/checked-compiler-option
[big-integer]: https://docs.microsoft.com/en-us/dotnet/api/system.numerics.biginteger?view=netcore-3.1

Casting and type conversion [are different ways of changing an expression from one data type to another][wiki-casting].

The [C# documentation][type-testing-and-cast-operators] classifies type conversion as the use of the [`as` operator][as-operator] or [`is` operator][is-operator]. Casting is defined as the use of the [cast operator][cast-operator].

In C# very often, outside of the realm of numeric values and class hierarchies, you will have to make a conversion by calling some member of the "to" type such as [`Int32.Parse()`][int32-parse] which converts a string to an integer or by calling a member of the "from" type e.g. `object.ToString()`. Javascript and developers in other dynamic languages should be aware.

Note that implicit an explicit cast [operators][operator-overloading] (discussed in (TODO cross-ref-tba)) are available which can bring fairly arbitrary casting to your own types.

#### Casting Primitive Types - Implicit

C#'s type system is somewhat stricter than _C_'s or Javascript's and as a consequence, casting operations are more restricted. [Implicit casting][implicit-casts] takes place between two numeric types as long as the "to" type can preserve the scale and sign of the "from" type's value. Note in the documentation the exception for converting to real numbers where precision may be lost.

An implicit cast is not signified by any special syntax. For example:

```csharp
int myInt = 1729;
long myLong = myInt;
```

There is no implicit conversion of a numeric (or string) expression to `bool`.

An expression of type `char` can be implicitly cast to `int`. The cast in the opposite direction must be explicit. Not all values of `int` are valid utf 16 chars.

#### Casting Primitive Types - Explicit

Where numeric types cannot be cast implicitly you can generally use the explicit cast [operator][cast-operator].

Where the value being cast cannot be represented by the "to" type because it is insufficiently wide or there is a sign conflict then an overflow exception may be thrown in the case of integers, or the "to" type variable may take a value of `Infinity` in the case of floats and doubles.

An expression of type `int` can be explicitly cast to `char`. This may result in an invalid `char`.

#### Casting Primitive Types - Examples

```csharp
int largeInt = Int32.MaxValue;
int largeNegInt = Int32.MinValue;
ushort shortUnsignedInt = ushort.MaxValue;
float largeFloat = float.MaxValue;
float smallFloat = 17.29f;

// implicit cast
int from_ushort = shortUnsignedInt;          // 65535
float from_int = largeInt;                   // -21474836E+09
int from_char = 'a';                         // 96

// explicit cast
uint from_largeInt = (uint)largeInt;         // 2147483647
uint from_neg = (uint) largeNegInt;          // 2147483648 or OverflowException is thrown (if checked)
int from_smallFloat = (int) smallFloat;      // 17
int from_largeFloat = (int) largeFloat;      // -2147483648 or OverflowException is thrown (if checked)
char from_intc = (char) 32;                  // ' '
char from_invalid_int = (char) 0xdcbf;       // invalid char - no exception thrown

// no cast available
int fromString = Int32.Parse("42");          // 42
string toString = largeInt.ToString();       // "2147483647"
int fromString_bad = Int32.Parse("forty two");     // FormatException is thrown
```

See this [article][checked] for the _**checked**_ keyword.

#### Type Conversion for types in a hierarchy

Any type can be implicitly converted to its base class or interface.

```csharp
IList<int> ll = new List<int>();
```

A cast operator can be used to convert from a base to a derived class.

```csharp
IList<int> ll = new List<int>();
List<int> l = (List<int>)ll;
```

If the cast fails because the type of the expression being cast is not related to the type it is being cast to an instance of `InvalidCastException` is thrown.

A more usual approach to these type conversions is to use the [`is`][is-operator] keyword:

```csharp
interface IFoo { int Bar(); }
class Foo : IFoo { public int Bar() { return 42; }}
Object r = new Random();
IFoo ifoo = new Foo();
Object o = new Foo();

int result = 1729;

if (ifoo is Foo foo)
{
    result = foo.Bar();
}
// result == 42

result = 1729;
if (o is Foo foo2)
{
    result = foo2.Bar();
}
// result == 42

result = 1729;
if (r is Foo foo3)
{
    result = foo3.Bar();
}
// result == 1729
```

The [`as`][as-operator] keyword fulfills a similar function to `is` e.g. `var foo = ifoo as Foo;`. In this example `foo` will be `null` if `ifoo` is not of type `Foo` otherwise `ifoo` will be assigned to it.

#### Custom Cast Operator

Types can define their own custom explicit and implicit [cast operators][custom-casts]. See (TODO cross-ref-tba) for coverage of this..

Examples of [explicit][big-integer-explicit] and [implicit][big-integer-implicit] casts in the BCL is conversions from the `BigInteger` struct to and from other numeric types

#### Using `typeof`

If you need to detect the precise type of an object then `is` may be a little too permissive as it will convert an object to a class or any of its base classes. `typeof` and `Object.GetType()` are the solution in this case.

```csharp
object o = new List<int>();

o is ICollection<int> // true
o.GetType() == typeof(ICollection<int>) // false
o is List<int> // true
o.GetType() == typeof(List<int>) // true
```

#### General

- [Type testing and cast operators][type-testing-and-cast-operators]: introduction to type testing and casting.
- [cast operator][cast-operator]: the cast operator.
- [`is` operator][is-operator]: `is` operator reference.
- [`as`-operator][as-operator]: `as` operator reference.
- [`typeof` operator][typeof-operator]: `typeof` operator reference.
- [Type conversion exceptions][type-conversion-exceptions]: explains when a runtime exception is thrown when doing casts.

[type-testing-and-cast-operators]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast
[is-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast#is-operator
[as-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast#as-operator
[cast-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast#cast-expression
[typeof-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast#typeof-operator
[type-conversion-exceptions]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/casting-and-type-conversions#type-conversion-exceptions-at-run-time
[wiki-casting]: https://en.wikipedia.org/wiki/Type_conversion
[implicit-casts]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions
[explicit-casts]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions#explicit-numeric-conversions
[int32-parse]: https://docs.microsoft.com/en-us/dotnet/api/system.int32.parse?view=netcore-3.1
[operator-overloading]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-overloading
[checked]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/checked
[custom-casts]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators
[big-integer-implicit]: https://docs.microsoft.com/en-us/dotnet/api/system.numerics.biginteger.op_implicit?view=netcore-3.1
[big-integer-explicit]: https://docs.microsoft.com/en-us/dotnet/api/system.numerics.biginteger.op_explicit?view=netcore-3.1

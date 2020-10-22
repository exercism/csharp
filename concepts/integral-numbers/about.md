C#, like many statically typed languages, provides a number of types that represent integers, each with its own [range of values][integral-numeric-types]. At the low end, the `sbyte` type has a minimum value of -128 and a maximum value of 127. Like all the integer types these values are available as `<type>.MinValue` and `<type>.MaxValue`. At the high end, the `long` type has a minimum value of -9,223,372,036,854,775,808 and a maximum value of 9,223,372,036,854,775,807. In between lie the `short` and `int` types.

Each of the above types is paired with an unsigned equivalent: `sbyte`/`byte`, `short`/`ushort`, `int`/`uint` and `long`/`ulong`. In all cases the range of the values is from 0 to the negative signed maximum times 2 plus 1.

Values of unsigned integral types are represented with a simple [base 2][wiki-binary] representation. Values of signed types use [2s complement][wiki-twos-complement] signed number representation.

The multiplicity of integer types reflects machine architectures, in the size of registers, the size of CPU instruction arguments and the treatment of sign within the CPU. A value of type `long` uses 64 bits whereas a value of type `sbyte` uses 8 bits. In some cases there will be implications on CPU performance, memory usage and even disk usage (where selection of a smaller integer type will generally be beneficial). Selection of integer `type` can also be a rough and ready wsy of communicating information to other developers about the expected range of values. The `int` type is widely used as the default type where nothing special has been identified about the particular usage. The `long` or `ulong` is widely used as a simple identifier. The size of the type in bytes determines the range of values.

The types discussed so far are _primitive_ types. Each is paired with a `struct` alias which implements fields (such as `MinValue`) and methods (such as `ToString()`) which are associated with the type.

| Type     | Struct   | Width  | Minimum                    | Maximum                     |
| -------- | -------- | ------ | -------------------------- | --------------------------- |
| `sbyte`  | `SByte`  | 8 bit  | -128                       | +127                        |
| `short`  | `Int16`  | 16 bit | -32_768                    | +32_767                     |
| `int`    | `Int32`  | 32 bit | -2_147_483_648             | +2_147_483_647              |
| `long`   | `Int64`  | 64 bit | -9_223_372_036_854_775_808 | +9_223_372_036_854_775_807  |
| `byte`   | `Byte`   | 8 bit  | 0                          | +255                        |
| `ushort` | `UInt16` | 16 bit | 0                          | +65_535                     |
| `uint`   | `UInt32` | 32 bit | 0                          | +4_294_967_295              |
| `ulong`  | `UInt64` | 64 bit | 0                          | +18_446_744_073_709_551_615 |

#### Casting

A variable (or expression) of one type can easily be converted to another. For instance, in an assignment operation, if the type of the value being assigned (rhs) ensures that the value will fit within the range of the type being assigned to (lhs) then there is a simple assignment:

```csharp
ulong ul;
uint ui = uint.MaxValue;
ul = ui;    // no problem
```

On the other hand if the range of type being assigned from is not a subset of the assignee's range of values then a cast, `()` operation is required even if the particular value is within the assignee's range:

```csharp
uint ui;
short s = 42;
ui = (uint)s;
```

In the above example, if the value lay instead outside the range of the assignee then an overflow would occur. See (TODO cross-ref-tba).

The requirement for casting is determined by the two types involved rather than a particular value.

The following paragraphs discuss the casting of integral types. (TODO cross-ref-tba casting) provides a broader discussion of casting and type conversion. See that documentation for a discussion of conversion between integral types and floating-point numbers, `char` and `bool`.

##### Casting Primitive Types - Implicit

C#'s type system is somewhat stricter than _C_'s or Javascript's and as a consequence, casting operations are more restricted. [Implicit casting][implicit-casts] takes place between two numeric types as long as the "to" type can preserve the scale and sign of the "from" type's value.

An implicit cast is not signified by any special syntax.

##### Casting Primitive Types - Explicit

Where numeric types cannot be cast implicitly you can generally use the explicit cast [operator][cast-operator].

Where the value being cast cannot be represented by the "to" type because it is insufficiently wide or there is a sign conflict then an overflow exception may be thrown.

#### Casting Primitive Types - Examples

```csharp
int largeInt = Int32.MaxValue;
int largeNegInt = Int32.MinValue;
ushort shortUnsignedInt = ushort.MaxValue;

// implicit cast
int from_ushort = shortUnsignedInt;          // 65535
float from_int = largeInt;                   // -21474836E+09

// explicit cast
uint from_largeInt = (uint)largeInt;         // 2147483647
uint from_neg = (uint) largeNegInt;          // 2147483648 or OverflowException is thrown (if checked)

```

#### Bit conversion

The `BitConverter` class provides a convenient way of converting integer types to and from arrays of bytes.

#### Reference

- [Integral numeric types][integral-numeric-types]: overview of the integral numeric types.
- [Numeric conversions][numeric-conversions]: overview of implicit and explicit numeric conversions.

[integral-numeric-types]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
[numeric-conversions]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions
[cast-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast#cast-expression
[implicit-casts]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions
[wiki-twos-complement]: https://en.wikipedia.org/wiki/Two%27s_complement
[wiki-binary]: https://en.wikipedia.org/wiki/Binary_number
[sbyte]: https://docs.microsoft.com/en-us/dotnet/api/system.sbyte?view=netcore-3.1

The C# `enum` type represents a fixed set of named constants (an enumeration). Normally, one can only refer to exactly one of those named constants. However, sometimes it is useful to refer to more than one constant. To do so, one can annotate the `enum` with the `Flags` attribute. A _flags_ enum's constants are interpreted as bitwise _flags_.

A flags enum can be defined as follows (using binary integer notation):

```csharp
[Flags]
enum PhoneFeatures
{
    Call = 0b00000001,
    Text = 0b00000010
}
```

A `PhoneFeatures` instance which value is `0b00000011` has both its `Call` _and_ `Text` flags set.

To work with bits, C# supports the following operators:

- `~`: bitwise complement
- `<<`: left shift
- `>>`: right shift
- `&`: logical AND
- `|`: logical OR
- `^`: logical XOR

Here is an example how to use a bitwise operator:

```csharp
1 << 2
// => 4
```

By default, the `int` type is used for enum member values. One can use a different integer type by specifying the type in the enum declaration:

```csharp
[Flags]
enum PhoneFeatures : byte
{
    Call = 0b00000001,
    Text = 0b00000010
}
```

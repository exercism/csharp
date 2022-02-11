# Introduction

The C# [`enum` type](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum) represents a fixed set of named constants (an enumeration).

Normally, one `enum` member can only refer to exactly one of those named constants. However, sometimes it is useful to refer to more than one constant. To do so, one can annotate the `enum` with the [`Flags` attribute](https://docs.microsoft.com/en-us/dotnet/api/system.flagsattribute?view=net-6.0). A _flags_ enum's constants are interpreted as bitwise _flags_ and therefor indicates the enum supports the bitwise operators and additional features like the method `Enum.HasFlag()`.

A flags enum can be defined as follows (using binary integer notation `0b`):

```csharp
[Flags]
enum PhoneFeatures
{
    Call = 0b00000001,
    Text = 0b00000010
}
```

A `PhoneFeatures` instance which value is `0b00000011` has both its `Call` _and_ `Text` flags set.

By default, the `int` type is used for enum member values. One can use a different integer type by specifying the type in the enum declaration:

```csharp
[Flags]
enum PhoneFeatures : byte
{
    Call = 0b00000001,
    Text = 0b00000010
}
```

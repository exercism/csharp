# Introduction

## Attributes

A [C# `Attribute`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/) provides a way to decorate a declaration to associate metadata to: a class, a method, an enum, a field, a property or any [other supported](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/#attribute-targets) declarations.

You can apply an attribute by adding it on the line before the declaration using a `ClassAttribute` and a `FieldAttribute`:

```csharp
[Class]
class MyClass
{
    [Field]
    int myField;
}
```

This declarative metadata only associates additional structured information to the code and does not modify its behavior, but that metadata is used by other part of the code to change how its target would behave or add, change or remove, restrict some its functionalities.

There is many [predefined and reserved attributes](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/general#conditional-attribute), for example: `Flags`, `Obsolete`, `Conditional`, each has a specific that can be looked up on the C# documentation. Note that the full name of an attribute like [`Flags`](https://docs.microsoft.com/en-us/dotnet/api/system.flagsattribute?view=net-6.0) is `FlagsAttribute` by convention, but the suffix _Attribute_ can be omitted when applied on a declaration.

## Flag Enums

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

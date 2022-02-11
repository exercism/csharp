# About

A [C# `Attribute`][attribute-concept] provides a way to decorate a declaration to associate metadata to: a class, a method, an enum, a field, a property or any [other supported][attribute-targets] declarations.

You can apply [an attribute][attribute] to a declaration by adding it between brackets `[]` before the declaration, the following example uses both a `ClassAttribute` and a `FieldAttribute`:

```csharp
[Class]
public class MyClass
{
    [Field] public int myField;
}
```

The declarative metadata only associates additional structured information to the code and does not modify its behavior, but that metadata is used by other part of the code to change how its target would behave or add, change or remove, restrict some its functionalities.

Multiple predefined attributes exist like: `Flags`, `Obsolete`, `Conditional`. Note that the full name of the [`Flags` attribute][flags-attribute] is `FlagsAttribute`, but "Attribute" suffix can be omitted when using in the attribute.

The following four predefined attributes are used regularly:

- `[Flags]`: Predefined in the System namespace. Indicates the enum supports both bitwise operations and the method `Enum.HasFlag()`, additionally `ToString` would display all the flags: [see example][flags-example].
- `[Obsolete]`: Predefined in the System namespace. Allows to add a message about why the code is obsolete, it can be used to display compiler warnings or errors.
- `[Conditional]`: Predefined in the System.Diagnostics namespace. Allows to remove some method calls at compile time for debugging (diagnostics) purposes.
- `[CallerMemberName]`: Predefined in the System.Runtime.CompilerServices namespace. Allows a method to obtain information about its caller.

[attribute-concept]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/
[attribute]: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/attributes
[attribute-targets]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/#attribute-targets
[flags-attribute]: https://docs.microsoft.com/en-us/dotnet/api/system.flagsattribute?view=net-6.0
[flags-example]: https://docs.microsoft.com/en-us/dotnet/api/system.flagsattribute?view=net-6.0#examples

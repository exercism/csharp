TODO: we need to reconsider the text below now that it is a stand alone concept or maybe bitwise manipulation should be introduced in a separate exercise and the flag-enums exercise and concept should take that as a dependency showing how bitwise manipulation is used in the context of enums.
To allow a single enum instance to represent multiple values (usually referred to as _flags_), one can annotate the enum with the `[Flags]` attribute. By carefully assigning the values of the enum members such that specific bits are set to `1`, bitwise operators can be used to set or unset flags.

```csharp
[Flags]
enum PhoneFeatures
{
    Call = 1,
    Text = 2
}
```

Besides using regular integers to set the flag enum members' values, one can also use [binary literals or the bitwise shift operator][binary-literals].

```csharp
[Flags]
enum PhoneFeaturesBinary
{
    Call = 0b00000001,
    Text = 0b00000010
}

[Flags]
enum PhoneFeaturesBitwiseShift
{
    Call = 1 << 0,
    Text = 1 << 1
}
```

An enum member's value can refer to other enum members values:

```csharp
[Flags]
enum PhoneFeatures
{
    Call = 0b00000001,
    Text = 0b00000010,
    All  = Call | Text
}
```

Setting a flag can be done through the [bitwise OR operator][or-operator] (`|`) and unsetting a flag through a combination of the [bitwise AND operator][and-operator] (`&`) and the [bitwise complement operator][bitwise-complement-operator] (`~`). While checking for a flag can be done through the bitwise AND operator, one can also use the enum's [`HasFlag()` method][has-flag].

```csharp
var features = PhoneFeatures.Call;

// Set the Text flag
features = features | PhoneFeatures.Text;

features.HasFlag(PhoneFeatures.Call); // => true
features.HasFlag(PhoneFeatures.Text); // => true

// Unset the Call flag
features = features & ~PhoneFeatures.Call;

features.HasFlag(PhoneFeatures.Call); // => false
features.HasFlag(PhoneFeatures.Text); // => true
```

[docs.microsoft.com-enumeration-types-as-bit-flags]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/enumeration-types#enumeration-types-as-bit-flags
[alanzucconi.com-enum-flags-and-bitwise-operators]: https://www.alanzucconi.com/2015/07/26/enum-flags-and-bitwise-operators/
[or-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-or-operator-
[and-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-and-operator-
[bitwise-complement-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#bitwise-complement-operator-
[binary-literals]: https://riptutorial.com/csharp/example/6327/binary-literals
[has-flag]: https://docs.microsoft.com/en-us/dotnet/api/system.enum.hasflag?view=netcore-3.1

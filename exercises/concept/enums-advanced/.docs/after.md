To allow a single enum instance to represent multiple values (usually referred to as _flags_), one can annotate the enum with the `[Flags]` attribute. By assigning the values of the enum members such that each value has exactly one bit set to `1`, bitwise operators can be used to set or unset flags.

Setting a flag can be done through the [bitwise OR operator][or-operator] (`|`) and unsetting a flag through a combination of the [bitwise AND operator][and-operator] (`&`) and the [bitwise complement operator][bitwise-complement-operator] (`~`). While checking for a flag can be done through the bitwise AND operator, one can also use the enum's [`HasFlag()` method][has-flag].

Besides using regular integers to set the flag enum members' values, one can also use [binary literals or the bitwise shift operator][binary-literals].

Note that an enum member's value can refer to other enum members values.

The [working with enums as bit flags tutorial][docs.microsoft.com-enumeration-types-as-bit-flags] goes into more detail how to work with flag enums. Another great resource is the [enum flags and bitwise operators page][alanzucconi.com-enum-flags-and-bitwise-operators].

[docs.microsoft.com-enumeration-types-as-bit-flags]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/enumeration-types#enumeration-types-as-bit-flags
[alanzucconi.com-enum-flags-and-bitwise-operators]: https://www.alanzucconi.com/2015/07/26/enum-flags-and-bitwise-operators/
[or-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-or-operator-
[and-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-and-operator-
[bitwise-complement-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#bitwise-complement-operator-
[binary-literals]: https://riptutorial.com/csharp/example/6327/binary-literals
[has-flag]: https://docs.microsoft.com/en-us/dotnet/api/system.enum.hasflag?view=netcore-3.1

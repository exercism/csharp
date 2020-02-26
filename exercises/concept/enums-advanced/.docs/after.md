To allow an enum value to represent multiple values (usually referred to as _flags_), one can annotate the enum with the `[Flags]` attribute. By assigning the values of the enum such that each values has exactly one bit set to `1`, bitwise operators can be used to set or unset flags.

The [working with enums as bit flags tutorial][docs.microsoft.com-enumeration-types-as-bit-flags] goes into more detail how to work with flag enums. Another great resource is the [enum flags and bitwise operators page][alanzucconi.com-enum-flags-and-bitwise-operators].

[docs.microsoft.com-enumeration-types-as-bit-flags]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/enumeration-types#enumeration-types-as-bit-flags
[alanzucconi.com-enum-flags-and-bitwise-operators]: https://www.alanzucconi.com/2015/07/26/enum-flags-and-bitwise-operators/

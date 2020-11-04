## Learning objectives

- Know what a flags enumeration is.
- Know how to define a flags enumeration.
- Know how to check if a flag has been set on an enum value.
- Know how to set a flag on an enum value.
- Know how to unset a flag on an enum value.
- Know that an enum's underlying type can be changed.
- Know how to use bitwise operators to manipulate bits.

## Out of scope

As this is an advanced exercise, there are no enum-related things that we should explicitly _not_ teach.

## Concepts

- `flag-enums`: know how to define a "flags" enum; know how to add, remove or check for flags; know how to change the underlying type of an enum.
- `bit-manipulation`: know how to use bitwise operators to manipulate bits.
- `compound-assignment`: know how to use compound assignments )`&=`, etc)

## Prerequisites

This exercise's prerequisites Concepts are:

- `enums`: know how to define the `enum`.
- `attributes`: know how to annotate the enum with the `[Flags]` attribute.
- `integers`: know of other integer types than `int` and know about binary integer literals.

## Representer

This exercise does not require any specific representation logic to be added to the [representer][representer].

## Analyzer

This exercise could benefit from having an [analyzer][analyzer] that can comment on:

- Verify that the `Permission` enum is marked with the `[Flags]` attribute.
- Suggest using `byte` as the enum's backing type if no backing type was explicitly specified.

[analyzer]: https://github.com/exercism/csharp-analyzer
[representer]: https://github.com/exercism/csharp-representer
[docs.microsoft.com-enumeration-types-as-bit-flags]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/enumeration-types#enumeration-types-as-bit-flags
[docs.microsoft.com-bitwise-and-shift-operators]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators
[docs.microsoft.com-switch-keyword]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch
[docs.microsoft.com-binary-notation]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types#integer-literals
[docs.microsoft.com-flagsattribute]: https://docs.microsoft.com/en-us/dotnet/api/system.flagsattribute?view=netcore-3.1
[alanzucconi.com-enum-flags-and-bitwise-operators]: https://www.alanzucconi.com/2015/07/26/enum-flags-and-bitwise-operators/
[concept-bitwise-manipulation]: ../../../../../reference/concepts/bitwise_manipulation.md

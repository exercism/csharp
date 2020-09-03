## Learning objectives

- Know how to use the `ToString()` method to convert any object to a `string`.
- Know how to use string interpolation on values of any type.
- Know how to use default format strings to convert to standard output formats.
- Know how to use custom format strings to convert to custom output formats.
- Know that `string.Format` underlies string interpolation.
- Know of the `StringBuilder` type and when to use it.
- Know that string interpolation can interpolate any expression.

## Out of scope

`IFormatProvider`, `ICustomFormatter`

## Concepts

- `string-formatting`: know how to use the `ToString()` method to convert any object to a `string`; know how to use string interpolation on values of any type; know how to use default format strings to convert to standard output formats; know how to use custom format strings to convert to custom output formats; know that `string.Format` underlies string interpolation; know that string interpolation can interpolate any expression.
- `verbatim-strings`: the syntax of verbatim strings
- `interpolation`: know how the syntax of interpolated strings; know when to use string interpolation

## Prerequisites

- `strings`: strings will be formatted.
- `inheritance`: knowing that each class derives from `object` and thus has built-in methods.
- `const-readonly`
- `time`: for use of `CultureInfo`.
- `varargs`: for the common overload of `public static string Format (string format, params object[] args);`
- `string-builder`: know of the `StringBuilder` type and when to use it

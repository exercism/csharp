## General

- [Integral numeric types][integral-numeric-types]: overview of the integral numeric types.
- [Numeric conversions][numeric-conversions]: overview of implicit and explicit numeric conversions.

## 1. Encode an integral value ready to send

- Conversion to a byte array is dealt with [here][bit-converter-get-bytes]

## 2. Decode a received buffer

- Converting from a byte array is discussed [here][bit-converter-to-type]

[integral-numeric-types]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
[numeric-conversions]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions
[bit-converter-get-bytes]: https://docs.microsoft.com/en-us/dotnet/api/system.bitconverter.getbytes?view=netcore-3.1
[bit-converter-to-type]: https://docs.microsoft.com/en-us/dotnet/api/system.bitconverter.toint16?view=netcore-3.1

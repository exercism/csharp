## General

- [Tutorial on working with enums][docs.microsoft.com-enumeration-types].

## 1. Parse log level

- There is a [method to get a part of a string](https://docs.microsoft.com/en-us/dotnet/api/system.string.substring?view=netcore-3.1).
- You can use a [`switch` statement](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch) to elegantly handle the various log levels.

## 2. Support unknown log level

- There is a [special switch case](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch#the-default-case) that can be used to catch unspecified cases.

## 3. Convert log line to short format

- One can [assign specific values to enum members][docs.microsoft.com_creating-an-enumeration-type].
- Converting an enum to a number can be done through [casting][docs.microsoft.com_enumeration-types-casting] or by using a [format string][docs.microsoft.com_system.enum.tostring].

[docs.microsoft.com-enumeration-types]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/enumeration-types
[docs.microsoft.com_enumeration-types-casting]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/enumeration-types#code-try-1
[docs.microsoft.com_creating-an-enumeration-type]: https://docs.microsoft.com/en-us/dotnet/api/system.enum?view=netcore-3.0#creating-an-enumeration-type

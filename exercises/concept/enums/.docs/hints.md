# Hints

### General

- [Tutorial on working with enums][docs.microsoft.com-enumeration-types].

### 1. Parse log level

- The `Enum` class has several [utility methods][docs.microsoft.com_system.enum-methods] to help with converting (parsing) a string to an enum.
- There is an option to ignore casing when parsing an enum.

### 2. Support unknown log level

- The `Enum` class' parsing methods also have similar methods that don't fail when not being able to parse an enum.

### 3. Convert log line to short format

- Converting an enum to a number can be done through [casting][docs.microsoft.com_enumeration-types-casting] or by using a [format string][docs.microsoft.com_system.enum.tostring].

[docs.microsoft.com-enumeration-types]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/enumeration-types
[docs.microsoft.com_system.enum-methods]: https://docs.microsoft.com/en-us/dotnet/api/system.enum?view=netcore-3.0#methods
[docs.microsoft.com_system.enum.tostring]: https://docs.microsoft.com/en-us/dotnet/api/system.enum.tostring?view=netcore-3.0
[docs.microsoft.com_enumeration-types-casting]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/enumeration-types#code-try-1

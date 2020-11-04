## General

- [String interpolation][string-interpolation]: tutorial on how to use string interpolation.
- [Formatting types][formatting-types]: the available format types to use.
- [Standard numeric format strings][standard-numeric-format-strings]: lists the standard numeric format strings.
- [Custom numeric format strings][custom-numeric-format-strings]: describes how to define custom numeric format strings.
- [Standard date and time format strings][standard-date-and-time-format-strings]: lists the standard date and time format strings.
- [Custom date and time format strings][custom-date-and-time-format-strings]: describes how to define custom date and time format strings.
- [`String.Format()`][string-format]: Library API.

## 1. Display the couple's name separated by a heart

- Take a look at the discussion of [string interpolation][string-interpolation].

## 2. Display the couple's initials in an ascii art heart

- This [article][verbatim-strings] discusses verbatim strings literals.
- This [document][string-format] discusses `String.Format()`.

## 3. German exchange students should be made to feel at home with locale-sensitive declarations.

- To work with interpolated strings view the documentation for [`FormattableString`][formattable-string]. It may be better, to start with, to use [composite formatting][composite-formatting].
- You will need to work with [`CultureInfo`][culture-info]. Note that it implements the [`IFormatProvider`][format-provider] interface.

[string-interpolation]: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/string-interpolation
[format-provider]: https://docs.microsoft.com/en-us/dotnet/api/system.iformatprovider?view=netcore-3.1
[custom-formatter]: https://docs.microsoft.com/en-us/dotnet/api/system.icustomformatter?view=netcore-3.1
[string-format]: https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=netcore-3.1#System_String_Format_System_String_System_Object_System_Object_System_Object_
[verbatim-strings]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#regular-and-verbatim-string-literals
[culture-info]: https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo?view=netcore-3.1
[formattable-string]: https://docs.microsoft.com/en-us/dotnet/api/system.formattablestring?view=netcore-3.1
[formatting-types]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/formatting-types
[standard-numeric-format-strings]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
[custom-numeric-format-strings]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings
[standard-date-and-time-format-strings]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings
[custom-date-and-time-format-strings]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
[composite-formatting]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting

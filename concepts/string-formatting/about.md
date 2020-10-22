Mechanisms for formatting strings are many and various in C#/.NET: everything from simple concatenation of objects through calls to the overridden `object.ToString()` method to use of [`ICustomFormatter`][custom-formatter] (not covered in this exercise).

The two most common mechanisms for formatting strings are [string interpolation][string-interpolation] and [String.Format()][string-format]. The [`StringBuilder`][string-builder] (cross-ref-tba) class can also be used to build up a string if there is complexity such as multiple lines involved.

#### Using `ToString()`

`System.Object()` from which all classes and structs inherit has a `ToString()` method. For example `new DateTime(2019, 5, 23).ToString()` will render "05/23/2019 00:00:00" (on a thread with US culture - [see below](#culture)). There are situations such as string concatenation where this default `ToString()` method may be invoked implicitly, `"" + new DateTime(2019, 5, 23)` gives the same result.

In addition to the default `ToString()` method, types where formatting is an issue will have overloads which take a [_format string_](#bcl-formatters-and-format-strings) or even a [format provider][format-provider]. Notably in the BCL (Base Class Library) these are numbers, dates, enums and GUIDs.

#### Composite Formatting

`String.Format()` takes a string (referred to in the documentation as a _composite format_) comprising fixed text and placeholders (known in the documentation as a _format items_) and a variable number of arguments. The return value resolves each _format item_ using the corresponding argument and combines the resolved values with the fixed text.

```csharp
string.Format("I had {0} bitcoins on {1}, the day I forgot my password.", 55.5, new DateTime(2010, 2, 25))
// => "I had 55.5 bitcoins on 2/25/2010 00:00:00, the day I forgot my password." - US settings
```

`Format()` may be a better choice than interpolation where the format is being used in multiple expressions as a kind of template or where incorporating the format, and the expressions to be formatted is too cumbersome such as when [verbatim strings][verbatim-strings] are involved.

This mechanism is technically known as [_composite formatting_][composite-formatting].

A fuller list of string producing methods that take advantage _composite formatting_ is given in this [article][composite-formatting].

#### String Interpolation

Interpolated strings are prefixed with a `$` and include run-time expressions enclosed in braces. The format item has the following syntax: `$"{<interpolationExpression>[,<alignment>][:<formatString>]}"`. They do away with the need for a separate list of arguments. The result is functionally equivalent to the `String.Format()` mechanism.

The expression can comprise anything in scope. _Alignment_ is the length of the "field" in which the text sits. If the _alignment_ is positive then the text is padded with spaces on the left and if it is negative then the padding is to the right of the text.

```csharp
var loadsOf = 55.5;
var thatDay = new DateTime(2010, 2, 25);
$"I had {loadsOf} bitcoins on {thatDay}, the day I forgot my password."
// => "I had 55.5 bitcoins on 2/25/2010 00:00:00, the day I forgot my password." - US settings
```

#### Format Items

The text in braces, placeholders in the case of the composite format and interpolated expressions in the case of string interpolation is known as a _format item_.

A format item can comprise up to 3 parts. The first is the mandatory expression or argument placeholder as seen in the example code above. In addition, there is an optional alignment (introduced with a comma, ",") and an optional _format string_ (introduced with a colon, ":").

`{<interpolationExpression>[,<alignment>][:<formatString>]}`

The _alignment_ specifies the length of the "field" in which the text is placed, padded to the left with spaces if the alignment is negative or to the right if it is positive.

The _format string_ specifies the shape of the text output such as whether thousands separators should be included for a number or whether the date part only of a `DateTime` object should be output.

The following code illustrates display of the date portion of a `DateTime` object and a floating-point number in exponential form.

```csharp
var loadsOf = 55.5;
var thatDay = new DateTime(2010, 2, 25);
$"I had {loadsOf:E} bitcoins on {thatDay:d}, the day I forgot my password."
// => I had 5.550000E+001 bitcoins on 02/25/2010, the day I forgot my password. - US settings

string.Format(
    "I had {0:E} bitcoins on {1:d}, the day I forgot my password.",
    loadsOf, thatDay)
// => I had 5.550000E+001 bitcoins on 02/25/2010, the day I forgot my password. - US settings

```

There is both standard and custom formatting for both numbers and dates. There is no vital difference between _custom_ and _standard_ except that you have a chance to compose custom format strings out of format characters. "custom" in this context has nothing to do with the [`ICustomFormatter`][custom-formatter] interface which is used when developing your own custom formatters.

#### BCL Formatters and Format Strings

The Base Class Library (BCL) provides 2 formatters: `DateTimeFormatInfo` and `NumberFormatInfo` and 6 groups of format strings.

The various lists of _format strings_ are below:

- [Standard numeric format strings][standard-numeric-format-strings]
- [Custom numeric format strings][custom-numeric-format-strings]
- [Standard date and time format strings][standard-date-and-time-format-strings]
- [Custom date and time format strings][custom-date-and-time-format-strings]
- [Enumeration format strings][enum-format-strings]
- [GUID format strings][guid-format-strings]

`Enum` and `GUID` _format strings_ can be classed as _standard_. Although `enum` and `GUID` have `ToString()` overloads that take an `IFormatProvider` it is not clear that it does anything.

An attempt is made in the library to instill some consistency into _format strings_ (beyond the fact that they are represented as strings). This push for consistency is found in the standard strings. In reality as a developer you rarely care about the difference between standard and custom strings. Although it is a good idea, if you are implementing formatters for your own classes to echo the existing standard strings if your classes appear to call for it, you can pretty well ignore the difference.

#### Culture

Each thread of execution has a default culture `Thread.CurrentThread.CurrentCulture` encapsulated in an instance of `CultureInfo`. The thread's culture determines how dates and numbers are formatted by default with respect to regional variations such as the difference in conventional date format between the UK _DD/MM/YYYY_ and the US _MM/DD/YYYY_.

`CultureInfo` implements the `IFormatProvider` interface which can be passed to certain overloads of `String.Format()`. This can be used to override the thread culture.

#### Reference Material

[string-interpolation]: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/string-interpolation
[string-interpolation-in-depth]: https://weblog.west-wind.com/posts/2016/Dec/27/Back-to-Basics-String-Interpolation-in-C#
[string-interpolation-advanced]: https://www.meziantou.net/interpolated-strings-advanced-usages.htm
[formatting-types]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/formatting-types
[standard-numeric-format-strings]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
[custom-numeric-format-strings]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings
[standard-date-and-time-format-strings]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings
[custom-date-and-time-format-strings]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
[string-builder]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/stringbuilder
[format-provider]: https://docs.microsoft.com/en-us/dotnet/api/system.iformatprovider?view=netcore-3.1
[custom-formatter]: https://docs.microsoft.com/en-us/dotnet/api/system.icustomformatter?view=netcore-3.1
[string-format]: https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=netcore-3.1#System_String_Format_System_String_System_Object_System_Object_System_Object_
[culture-info]: https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo?view=netcore-3.1
[composite-formatting]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting
[custom-string-interpolation]: https://thomaslevesque.com/2015/02/24/customizing-string-interpolation-in-c-6/
[enum-format-strings]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/enumeration-format-strings
[guid-format-strings]: https://docs.microsoft.com/en-us/dotnet/api/system.guid.tostring?view=netcore-3.1

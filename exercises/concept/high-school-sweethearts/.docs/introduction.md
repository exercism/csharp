There are two principal mechanisms for formatting strings in C#/.NET. Use of `String.Format()` and string interpolation.

## Composite Formatting

`String.Format()` takes a string (referred to in the documentation as a _composite format_) comprising fixed text and placeholders (known in the documentation as format items), and a variable number of arguments. The return value resolves each format item using the corresponding argument and combines the resolved values with the fixed text.

```csharp
string.Format("I had {0} bitcoins on {1}, the day I forgot my password.", 55.5, new DateTime(2010, 2, 25));
// => "I had 55.5 bitcoins on 2/25/2010 00:00:00, the day I forgot my password." - US settings
```

This mechanism is technically known as _composite formatting_.

## String Interpolation

Interpolated strings are prefixed with a `$` and include run-time expressions enclosed in braces. The format item has the following syntax: `$"{<interpolationExpression>}"`. They do away with the need for a separate list of arguments. The result is functionally equivalent to the `String.Format()` mechanism.

```csharp
var loadsOf = 55.5;
var thatDay = new DateTime(2010, 2, 25);
$"I had {loadsOf} bitcoins on {thatDay}, the day I forgot my password."
// => "I had 55.5 bitcoins on 2/25/2010 00:00:00, the day I forgot my password." - US settings
```

## Format Items

The text in braces, placeholders in the case of the composite format and interpolated expressions in the case of string interpolation is known as a _format item_.

A format item can comprise up to 3 parts. The first is the mandatory expression or argument placeholder as seen in the example code above. In addition, there is an optional alignment (introduced with a comma, ",") and an optional _format string_ (introduced with a colon ":").

`{<interpolationExpression>[,<alignment>][:<formatString>]`

The _alignment_ specifies the length of the "field" in which the text is placed, padded to the left with spaces if the alignment is negative or to the right if it is positive.

The _format string_ specifies the shape of the text output such as whether thousands separators should be included for a number or whether the date part only of a `DateTime` object should be output.

The following code illustrates display of the data portion of a `DateTime` object and a floating-point number in exponential form.

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

There are both standard and custom formatting for both numbers and dates. There is no vital difference between _custom_ and _standard_ except that you have a chance to compose custom format strings out of format letters.

## Culture

Each thread has a default culture `Thread.CurrentThread.CurrentCulture` encapsulated in an instance of `CultureInfo`. The thread's culture determines how dates and numbers are formatted with respect to regional variations such as the difference in conventional date format between the UK _DD/MM/YYYY_ and the US _MM/DD/YYYY_.

`CultureInfo` implements the `IFormatProvider` interface which can be passed to certain overloads of `String.Format()`. This can be used to override the thread culture.

## Verbatim Strings

Verbatim strings allow multi-line strings. They are introduced with an @.

```csharp
string str = @"
See no wretched
quotes everywhere
";
```

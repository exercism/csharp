`char`s are generally easy to use. They can be extracted from strings, added back
(by means of a string builder), defined and initialised using literals with single quotes, as in `char ch = 'A';`
, assigned and compared.

General information on `char`s can be found here:

- [Chars documentation][chars-docs]: reference documentation for `char`.
- [Chars tutorial][chars-tutorial]: basic tutorial on how to work with chars.

However, `char`s have a number of rough edges as detailed below.
These rough edges mostly relate to the opposition
between the full unicode standard on the one side and historic representations
of text as well as performance and memory usage on the other.

### Unicode Issues

When dealing with strings, if `System.String` library methods are available you should
seek these out and use them rather than breaking the string down into characters.
Some textual "characters" consist of more than one `char` because the unicode standard
has more than 65536 code points. For instance the emojis that show up in some
of the tests have 2 `char`s as they comprise [surrogate][surrogates] characters.
Additionally, there are combining sequences for instance where in some cases
an accented character may consist of one `char` for the plain character
and another `char` for the accent.

If you have to deal with individual characters you should try to use
library methods such as [`System.Char.IsControl`][is-control], [`System.Char.IsDigit`][is-digit]
rather than making naive comparisons such as checking that a character is
between '0' and '9'. For instance, note that '٢' is the arabic digit 2. `IsDigit`
will return true for the arabic version so you need to be clear say when validating
what range of inputs is acceptable. Even the `System.Char` library methods may not
behave as you would expect when you are dealing with more obscure languages.

One way safely to break a string into display "characters" is to use [`StringInfo`][string-info] and
methods such as [`GetNexttextElement`][get-next-text-element]. This might be necessary if you are
dealing with globalization/localization. Another avenue where the scalar values
of unicode characters is important (say you are rolling your own encoding system) is to use
[runes][runes]. However, if you know the range of characters
you deal with does not include surrogates or combining character sequences (e.g. Latin ASCII) and your input
is well validated then you can avoid this. Again, the best position to be in
is where you can use `String`'s library methods.

If you do find yourself in the unenviable position of dealing with the minutiae of unicode
then [this][char-encoding-net] is a good starting point.

### Globalization

If you are working in an environment where you are dealing with multiple cultures or
the culture is important in some parts of the code but not others then be
aware of the overloads of [`ToUpper`][to-upper] and [`ToLower`][to-lower] which take a culture and
[`ToUpperInvariant`][to-upper-invariant] and [`ToLowerInvariant`][to-lower-invariant] which will provide a consistent
result irrespective of the current [culture][culture-info].

### Representation, Characters and Integers

Like other simple types (`int`s, `bool`s, etc.) the `char` has a companion
or alias type, in this case, `System.Char`. This is in fact a `struct` with
a 16 bit field. `char` in fact has some instance methods such as
`Equals`, `ToString` and [`CompareTo`][compare-to].

`char` has the same width as a [`ushort`][uint16] but they are generally
not used inter-changeably as they are in some languages. `ushort` has
to be explicitly cast to a `char`. For what it's worth `char`s can
be subject to arithmetic operations. The result of these operations is an integer.

Obviously there is no equivalence between a `byte` at 8 bits and the 16 bit `char`.

[chars-docs]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/char
[chars-tutorial]: https://csharp.net-tutorials.com/data-types/the-char-type/
[culture-info]: https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo?view=netcore-3.1
[uint16]: https://docs.microsoft.com/en-us/dotnet/api/system.uint16?view=netcore-3.1
[string-info]: https://docs.microsoft.com/en-us/dotnet/api/system.globalization.stringinfo?view=netcore-3.1
[runes]: https://docs.microsoft.com/en-us/dotnet/api/system.text.rune?view=netcore-3.1
[char-encoding-net]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/character-encoding-introduction
[surrogates]: https://docs.microsoft.com/en-us/dotnet/api/system.char.issurrogate?view=netcore-3.1
[is-control]: https://docs.microsoft.com/en-us/dotnet/api/system.char.iscontrol?view=netcore-3.1
[to-upper]: https://docs.microsoft.com/en-us/dotnet/api/system.char.toupper?view=netcore-3.1#System_Char_ToUpper_System_Char_System_Globalization_CultureInfo_
[to-lower]: https://docs.microsoft.com/en-us/dotnet/api/system.char.tolower?view=netcore-3.1#System_Char_ToLower_System_Char_System_Globalization_CultureInfo_
[to-upper-invariant]: https://docs.microsoft.com/en-us/dotnet/api/system.char.toupperinvariant?view=netcore-3.1
[to-lower-invariant]: https://docs.microsoft.com/en-us/dotnet/api/system.char.tolowerinvariant?view=netcore-3.1
[is-digit]: https://docs.microsoft.com/en-us/dotnet/api/system.char.isdigit?view=netcore-3.1
[get-next-text-element]: https://docs.microsoft.com/en-us/dotnet/api/system.globalization.stringinfo.getnexttextelement?view=netcore-3.1
[compare-to]: https://docs.microsoft.com/en-us/dotnet/api/system.char.compareto?view=netcore-3.1

The .NET base class libraries provide the [`Regex`][regex] class for processing of regular expressions.

See this [article][regex-comparison] for a comparison of C# with other flavours of regular expressions.

#### Capture Groups

One aspect to consider is that of capture groups which return parts of the text matching various parts of the regex pattern. The approach to capture groups needs getting used to. See this [documentation][capture].

Note that there is a hierarchy where capture groups, `(?<capture-name>pattern)`, are involved:

- where a set of zero or more matches is returned (one for each match found in the text).
- Each match contains a number of capture groups
- Each group contains a number of captures.

In addition:

- `Match` is derived from `Group`
- `Group` is derived from `Capture`

Caveats:

- The safest approach is to use named captures.
- Capture groups do generally occur in the `Groups` collection in the same order as they appear in the text.
- `Groups[0]` appears to relate to the entire match.
- `Groups[<capture name>].Value` is almost certainly what you are interested in. Individual captures (other than `Caputures[0]`) appear to be for intended for diagnostic purposes if they are present.

#### Regex Options

Familiarise yourself with [`RegexOptions`][regex-options].

As well as the usual `IgnoreCase` options there are ones for `MultiLine` which is useful for processing multiple lines of text in one go and `IgnorePatternWhitespace` which when coupled with verbatim strings, string interpolation and comments can be very expressive as shown in this illustration:

```csharp
const string PREAMBLE = "preamble";
const string PWTEXT = "pwtext";
const string PW = "pw";
const string SPACE = "space";
const string POSTAMBLE = "postamble";

var pattern = $@"
    ^
    (?<{PREAMBLE}>.*)          # any text
    (?<{PWTEXT}>password)      # the literal text - password
    (?<{SPACE}>\s+)
    (?<{PW}>\w*)               # the password itself
    (?<{POSTAMBLE}>.*)         # any text
    $
  ";

var rewrittenLine = $"{grps[PREAMBLE].Value}{grps[PWTEXT].Value}{grps[SPACE].Value}{mask}{grps[POSTAMBLE].Value}";
```

Another option of interest is `RegexOptions.Compiled` for [compiled][regex-compilation] regexes.

[regular-expressions]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference
[regex]: https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=netcore-3.1
[so-groups-and-captures]: https://stackoverflow.com/questions/3320823/whats-the-difference-between-groups-and-captures-in-net-regular-expression
[regex-comparison]: https://en.wikipedia.org/wiki/Comparison_of_regular-expression_engines
[capture]: https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.capturecollection?view=netcore-3.1
[regex-options]: https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regexoptions?view=netcore-3.1
[regex-compilation]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/best-practices

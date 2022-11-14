# Introduction

The key to this exercise is to detect a specific type of sentence and then rewrite that sentence based on its parts.

## General guidance

- Regular expressions can be a natural fit, but beware of any readability issues

## Approach: regular expressions

```csharp
public static class PigLatin
{
    private static readonly Regex VowelRegex = new(@"(?<begin>^|\s+)(?<vowel>a|e|i|o|u|xr|yt)(?<rest>\w+)", RegexOptions.Compiled);
    private static readonly Regex ConsonantRegex = new(@"(?<begin>^|\s+)(?<consonant>ch|qu|thr|th|rh|sch|yt|\wqu|\w)(?<rest>\w+)", RegexOptions.Compiled);

    private const string VowelReplacement = "${begin}${vowel}${rest}ay";
    private const string ConsonantReplacement = "${begin}${rest}${consonant}ay";

    public static string Translate(string sentence) =>
        VowelRegex.IsMatch(sentence)
            ? VowelRegex.Replace(sentence, VowelReplacement)
            : ConsonantRegex.Replace(sentence, ConsonantReplacement);
}
```

This approach uses [regular expressions][regular-expressions] to match and rewrite the input sentence.
For more information, check the [regular expressions approach][approach-regular-expressions].

[approach-regular-expressions]: https://exercism.org/tracks/csharp/exercises/pig-latin/approaches/regular-expressions
[regular-expressions]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference

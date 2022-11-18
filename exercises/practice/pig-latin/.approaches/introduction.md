# Introduction

The key to this exercise is to detect a specific type of sentence and then rewrite that sentence based on its parts.

## General guidance

- Regular expressions can be a natural fit, but beware of any readability issues

## Approach: regular expressions

```csharp
public static class PigLatin
{
    private const string VowelPattern = @"(?<begin>^|\s+)(?<vowel>[aeiou]|xr|yt)(?<rest>\w+)";
    private const string ConsonantPattern = @"(?<begin>^|\s+)(?<consonant>([^aeiou]?qu|[^aeiou]+))(?<rest>[aeiouy]\w*)";

    private const string VowelReplacement = "${begin}${vowel}${rest}ay";
    private const string ConsonantReplacement = "${begin}${rest}${consonant}ay";

    public static string Translate(string sentence) =>
        Regex.IsMatch(sentence, VowelPattern)
            ? Regex.Replace(sentence, VowelPattern, VowelReplacement)
            : Regex.Replace(sentence, ConsonantPattern, ConsonantReplacement);
}
```

This approach uses [regular expressions][regular-expressions] to match and rewrite the input sentence.
For more information, check the [regular expressions approach][approach-regular-expressions].

[approach-regular-expressions]: https://exercism.org/tracks/csharp/exercises/pig-latin/approaches/regular-expressions
[regular-expressions]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference

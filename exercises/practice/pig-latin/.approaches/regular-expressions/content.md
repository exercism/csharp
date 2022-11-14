# Regular expressions

```csharp
using System.Text.RegularExpressions;

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

This approach uses [regular expressions][regular-expressions] to match _and_ rewrite the input sentence.
So how do we do that and is the code still readable?
Let's find out!

If we examine the exercise's rules, there are basically two types of sentence:

1. Those with vowel sounds, where "ay" is added to the end of the word
2. Non consonant sounds, where first the consonant is moved to the end of the word and then "ay" is added to the end of the word

## Vowel sounds

Let's start out simple and try implement rule number 1:

> - **Rule 1**: If a word begins with a vowel sound, add an "ay" sound to the end of the word. Please note that "xr" and "yt" at the beginning of a word make vowel sounds (e.g. "xray" -> "xrayay", "yttria" -> "yttriaay").

Let's focus on "If a word begins with a vowel sound" first.
We can detect the vowels using the following pattern: `(a|e|i|o|u)`.

Next up is detect if the word _begins_ with a vowel sounds.
There are two ways in which a word can "begin":

1. It is the first word, which means that it matches directly after the beginning of the input ([`^` anchor][regex-anchors])
2. It is _not_ the first word, which means that it is preceded by one or more (`+` quantifier) whitespace characters ([`\s`][regex-whitespace-character-group]).

Finally, we need to capture the rest of the word (the letters after the vowel), which are one or more letters ([`\w`][regex-word-character-group]).

Putting this all together, we get:

```csharp
(^|\s+)(a|e|i|o|u)(\w+)
```

It is then easy to support the additional rule that consonant words can also start with `"xr"` or `"yt"`:

```csharp
(^|\s+)(a|e|i|o|u|xr|yt)(\w+)
```

We can test if our sentence matches the regex using [`Regex.IsMatch()`][regex-ismatch]:

```csharp
Regex.IsMatch(@"(^|\s+)(a|e|i|o|u|xr|yt)(\w+)", sentence)
```

To make the regular expression somewhat more expressive, we can add [names to the sub-expressions][regex-named-matched-subexpression]:

```csharp
(?<begin>^|\s+)(?<vowel>a|e|i|o|u|yt|xr)(?<rest>\w+)
```

This better reflects our domain.

### Pre-compiling the regular expressions

As our regular expression is already somewhat _long-ish_, let's introduce a private field for it:

```csharp
private static readonly Regex VowelRegex = new(@"(?<begin>^|\s+)(?<vowel>a|e|i|o|u|yt|xr)(?<rest>\w+)", RegexOptions.Compiled);
```

```exercism/note
We define the regex pattern as a [_verbatim string_](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/verbatim), which is a `string` prefixed with an `@` character.
This will ensure that characters like a backslash are not interpreted as an escape character, but instead interpreted literally.
This is especially convenient when working with regular expressions, as one often uses backslashes.
```

```exercism/note
We create the `Regex` instance using `RegexOptions.Compiled`, which compiles the regular expression once instead of each time it is called.
```

### Rewriting the sentence

Now that we can detect vowel sounds, we can move on to rewriting the sentence.
You might think this to be as easy as:

```csharp
return sentence + "ay"
```

but this does not account for the fact that a sentence might have multiple words that need to be rewritten.
A better option is to use the match information from our regular expression, and use that information to rewrite the sentence.
Using our named capture groups, we can then do:

```csharp
VowelRegex.Replace(sentence, "${begin}${vowel}${rest}ay")
```

Pretty declarative, right?

Let's also extract the replacement pattern to a constant, which leads us to the following (non-compiling) code:

```csharp
private const string VowelReplacement = "${begin}${vowel}${rest}ay";

public static string Translate(string sentence)
{
    if (VowelRegex.IsMatch(sentence))
        return VowelRegex.Replace(sentence, VowelReplacement);
}
```

<!--
- **Rule 4**: If a word contains a "y" after a consonant cluster or as the second letter in a two letter word it makes a vowel sound (e.g. "rhythm" -> "ythmrhay", "my" -> "ymay").

- **Rule 2**: If a word begins with a consonant sound, move it to the end of the word and then add an "ay" sound to the end of the word. Consonant sounds can be made up of multiple consonants, a.k.a. a consonant cluster (e.g. "chair" -> "airchay").
- **Rule 3**: If a word starts with a consonant sound followed by "qu", move it to the end of the word, and then add an "ay" sound to the end of the word (e.g. "square" -> "aresquay"). -->

[regular-expressions]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference
[regex-ismatch]: https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch
[regex-replace]: https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.replace
[regex-character-classes]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions
[regex-word-character-group]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#word-character-w
[regex-whitespace-character-group]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#whitespace-character-s
[regex-anchors]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/anchors-in-regular-expressions
[regex-named-matched-subexpression]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/grouping-constructs-in-regular-expressions#named_matched_subexpression

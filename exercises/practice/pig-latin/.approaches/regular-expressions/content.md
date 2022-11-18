# Regular expressions

```csharp
using System.Text.RegularExpressions;

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

This approach uses [regular expressions][regular-expressions] to match _and_ rewrite the input sentence.
So how do we do that and is the code still readable?
Let's find out!

Looking at the exercise's rules, there are basically two types of words:

1. Starts with a vowel sound, where "ay" is added to the end of the word
2. Starts with a consonant sound, where first the consonant is moved to the end of the word and then "ay" is added to the end of the word

## Vowel sounds

Let's start out simple and try implement rule number 1:

> **Rule 1**: If a word begins with a vowel sound, add an "ay" sound to the end of the word. Please note that "xr" and "yt" at the beginning of a word make vowel sounds (e.g. "xray" -> "xrayay", "yttria" -> "yttriaay").

### Pattern: word begins with a vowel sound

Let's start by focusing on:

> If a word begins with a vowel sound, add an "ay" sound to the end of the word.

To match a vowel, we can use a [positive character group][regex-positive-character-group]: `[aeiou]`.
This will match when the character is one of the listed vowels.

We can add the [`+` quantifier][regex-quantifiers] to have it match one or more vowels: `[aeiou]+`.

To ensure that we only match vowels at the beginning of a word, we start our pattern with the [`^` anchor][regex-anchors], giving us the following pattern: `^[aeiou]+`.
This can be read as: match when the input starts with one or more vowels, which is exactly what we want.

We can test if a word matches our regex pattern using [`Regex.IsMatch()`][regex-ismatch]:

```csharp
Regex.IsMatch("a",     "^[aeiou]+") // true:  one matching vowel
Regex.IsMatch("io",    "^[aeiou]+") // true:  multiple matching vowels
Regex.IsMatch("bo",    "^[aeiou]+") // false: starts with different character
Regex.IsMatch("",      "^[aeiou]+") // false: doesn't match at least once
```

We can then implement our rule using the following code:

```csharp
if (Regex.IsMatch(word, "^[aeiou]+"))
    return word + "ay"
```

### Pattern: "xr" and "yt" at the beginning of a word make vowel sounds

Let's move on to the second part of rule 1:

> Please note that "xr" and "yt" at the beginning of a word make vowel sounds

We now have to deal with an either/or situation, where either the word begins with one or more vowels _or_ it has "xt" or "yt" at the start.
To support this, we can use the [`|` alternation construct][regex-either-or]: `^[aeiou]+|xr|yt`

Let's test this pattern:

```csharp
Regex.IsMatch("ai",  "^[aeiou]+|xr|yt") // true:  multiple matching vowels
Regex.IsMatch("yt",  "^[aeiou]+|xr|yt") // true:  starts with "yt"
Regex.IsMatch("xt",  "^[aeiou]+|xr|yt") // true   starts with "xt"
Regex.IsMatch("xtn", "^[aeiou]+|xr|yt") // true:  starts with "xt"
Regex.IsMatch("yr",  "^[aeiou]+|xr|yt") // false: character after 'y' is not 't'
Regex.IsMatch("wxt", "^[aeiou]+|xr|yt") // false: does not begin with "xt"
```

That works, yay!

### Supporting multiple words

After running the tests, you'll find that this method works for individual words, but doesn't work for sentences with multiple words.
So how do we replace multiple words, and not just one word?
Well, we change our regular expression a bit!

The trick is to have the regex match both words at the beginning of the sentence _and_ within the sentence.
In regular expression terms, this means that a word is either:

1. the first word, which means that it matches directly after the beginning of the input ([`^` anchor][regex-anchors])
2. is _not_ the first word, which means that it is preceded by one or more (`+` quantifier) whitespace characters ([`\s`][regex-whitespace-character-group]).

Using the fact that the `^` anchor can be used in a sub-expression, we can use the `|` construct and use: `^|\s+`:

The regex pattern then becomes:

```csharp
@"(^|\s+)([aeiou]+|xr|yt)"
```

As we are now using a backslash that should be interpreted as an escape character, we prefix the string with the `@` character, making it a [_verbatim string_](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/verbatim).

```exercism/note
Verbatim strings ensure that characters like a backslash are not interpreted as escape characters, but instead inserted literally.
This is especially convenient when working with regular expressions, as one often uses backslashes.
```

The next step is to replace all the words in our sentence using our regex pattern, which we can do with [`Regex.Replace()`][regex-replace].
This method takes an input, a matching pattern _and_ a replacement pattern.

The replacement pattern can refer to matched subexpression using `$i` placeholders, where `$0` is the entire string, `$1` is the first subexpression, etc.
Note that we need to parenthesize the subexpressions to enable us to refer to them in the replacement pattern:

```csharp
Regex.Replace("apple ear", @"(^|\s+)([aeiou]+|xr|yt)", "$1$2ay") // "aaypple eaayr"
```

Even though we refer to our subexpressions (via the `$1` and `$2` placeholders), the output is correct!
Why is that?

While we are matching the beginning of the word _and_ the starting vowels, we don't match the other characters of the word.
For that, we'll add a `\w+` at the end, which means: one or more word characters (which includes letters and digits).

```csharp
Regex.Replace("apple ear", @"(^|\s+)([aeiou]+|xr|yt)(\w+)", "$1$2$3ay") // "appleay earay"
```

And that works!

### Improving readability

To make the regular expression somewhat more readable, we can add [names to the sub-expressions][regex-named-matched-subexpression]:

```csharp
(?<begin>^|\s+)(?<vowel>[aeiou]|xr|yt)(?<rest>\w+)
```

We can then also use these names in our replacement pattern:

```csharp
Regex.Replace(sentence, @"(?<begin>^|\s+)(?<vowel>[aeiou]|xr|yt)(?<rest>\w+)", "${begin}${vowel}${rest}ay")
```

Arguably, this better reflects our domain rules.

### Refactoring to constants

As our regular expression pattern and replacement pattern are already somewhat _long-ish_, let's introduce constants for them:

```csharp
private const string VowelPattern = @"(?<begin>^|\s+)(?<vowel>[aeiou]|xr|yt)(?<rest>\w+)";
private const string VowelReplacement = "${begin}${vowel}${rest}ay";

public static string Translate(string sentence) =>
    Regex.Replace(sentence, VowelPattern, VowelReplacement);
```

## Consonant sounds

Let's move on to our other case: consonant sounds.

### Pattern: word begins with a consonant sound

> **Rule 2**: If a word begins with a consonant sound, move it to the end of the word and then add an "ay" sound to the end of the word. Consonant sounds can be made up of multiple consonants, a.k.a. a consonant cluster (e.g. "chair" -> "airchay").

Let's define a pattern to match a consonant.
We could list out all the consonant letters, but if we assume that our sentence only uses letters (which is true for the tests), we can also define it as not being a vowel character.
For that, we can use the `^` modified within a character group, to make it a [negative character group][regex-negative-character-group]:

```csharp
Regex.IsMatch("b", "[^aeiou]") // true
Regex.IsMatch("y", "[^aeiou]") // true
Regex.IsMatch("i", "[^aeiou]") // false
```

Applying what we've learnt when detecting words starting with a vowel sound, we can create a first version of our regex using:

```csharp
@"(?<begin>^|\s+)(?<consonant>[^aeiou]+)(?<rest>\w*)"
```

The replacement pattern is slightly different though, as the rule states that the consonant cluster at the beginning of the word needs to be moved to the end of the word, and then "ay" is appended.
We can capture this domain rule nicely in our replacement pattern:

```csharp
"${begin}${rest}${consonant}ay"
```

Let's introduce constants again:

```csharp
private const string ConsonantPattern = @"(?<begin>^|\s+)(?<consonant>([^aeiou]?qu|[^aeiou]+))(?<rest>[aeiouy]\w*)";
private const string ConsonantReplacement = "${begin}${rest}${consonant}ay";
```

And then we can do:

```csharp
Regex.Replace(sentence, ConsonantPattern, ConsonantReplacement)
```

### Pattern: word begins with a consonant sound followed by "qu"

Let's look at implementing the third rule:

> **Rule 3**: If a word starts with a consonant sound followed by "qu", move it to the end of the word, and then add an "ay" sound to the end of the word (e.g. "square" -> "aresquay").

We can match this using the following pattern: `[^aeiou]?qu`

Modifying our regular expression leads to:

```csharp
@"(?<begin>^|\s+)(?<consonant>([^aeiou]?qu|[^aeiou]+))(?<rest>\w*)"
```

Note that we have put the `[^aeiou]?qu` pattern _before_ `[^aeiou]+`, as the order does matter.

### Pattern: if a word contains a "y" after a consonant cluster or as the second letter in a two letter word it makes a vowel sound

The last rule is:

> **Rule 4**: If a word contains a "y" after a consonant cluster or as the second letter in a two letter word it makes a vowel sound (e.g. "rhythm" -> "ythmrhay", "my" -> "ymay").

This one's a bit more tricky, but we can solve this by modifying our "rest" sub-expression.
We know the rest must start with a vowel, as any consonants would have been matched in the "consonant" sub-expression.
We can thus safely change `(?<rest>\w*)` to `(?<rest>[aeiou]\w*)`.

Then all we need to change is to allow the rest to also start with a `y` character:

```csharp
(?<rest>[aeiouy]\w*)
```

Our consonant pattern now becomes:

```csharp
@"(?<begin>^|\s+)(?<consonant>([^aeiou]?qu|[^aeiou]+))(?<rest>[aeiouy]\w*)"
```

And with that, we've implemented all rules!

## End result

Putting all this together, we can now implement the `Translate()` method as follows:

```csharp
public static string Translate(string sentence) =>
    Regex.IsMatch(sentence, VowelPattern)
        ? Regex.Replace(sentence, VowelPattern, VowelReplacement)
        : Regex.Replace(sentence, ConsonantPattern, ConsonantReplacement);
```

## Performance

If you worry about the .NET runtime compiling the regular expression each time it executes, don't be!
The [implementation of the `IsMatch()` method][regex.is-match-source] uses a cache to only compile each pattern once:

```csharp
public static bool IsMatch(string input, string pattern) =>
    RegexCache.GetOrAdd(pattern).IsMatch(input);
```

[regular-expressions]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference
[regex-ismatch]: https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch
[regex-replace]: https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.replace
[regex-character-classes]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions
[regex-word-character-group]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#word-character-w
[regex-whitespace-character-group]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#whitespace-character-s
[regex-anchors]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/anchors-in-regular-expressions
[regex-named-matched-subexpression]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/grouping-constructs-in-regular-expressions#named_matched_subexpression
[regex.is-match-source]: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.RegularExpressions/src/System/Text/RegularExpressions/Regex.Match.cs#L14
[regex-positive-character-group]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#PositiveGroup
[regex-negative-character-group]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#negative-character-group-
[regex-quantifiers]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/quantifiers-in-regular-expressions
[regex-either-or]: https://learn.microsoft.com/en-us/dotnet/standard/base-types/alternation-constructs-in-regular-expressions#Either_Or

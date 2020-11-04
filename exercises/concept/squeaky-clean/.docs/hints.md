### 1. Replace any spaces encountered with underscores

- [This tutorial][chars-tutorial] is useful.
- [Reference documentation][chars-docs] for `char`s is here.
- You can retrieve `char`s from a string in the same way as elements from an array.
- You should use a [`StringBuilder`][string-builder] to build the output string.
- See [this method][iswhitespace] for detecting spaces. Remember it is a static method.
- `char` literals are enclosed in single quotes.

### 2. Replace control characters with the upper case string "CTRL"

- See [this method][iscontrol] to check if a character is a control character.

### 3. Convert kebab-case to camel-case

- See [this method][toupper] to convert a character to upper case.

### 4. Omit Greek lower case letters

- `char`s support the default equality and comparison operators.

[chars-docs]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/char
[chars-tutorial]: https://csharp.net-tutorials.com/data-types/the-char-type/
[string-builder]: https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=netcore-3.1
[iswhitespace]: https://docs.microsoft.com/en-us/dotnet/api/system.char.iswhitespace?view=netcore-3.1#System_Char_IsWhiteSpace_System_Char_
[iscontrol]: https://docs.microsoft.com/en-us/dotnet/api/system.char.iscontrol?view=netcore-3.1
[toupper]: https://docs.microsoft.com/en-us/dotnet/api/system.char.toupper?view=netcore-3.1
[equality]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators
[comparison]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/comparison-operators

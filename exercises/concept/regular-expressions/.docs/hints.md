## General

- [regular expressions][regular-expressions] documentation describes regexes and the flavour built into the .NET libraries.
- [Regex][regex] documentation describing the built-in library class.

### 1. Identify garbled log lines

- See [this discussion][ismatch] of matching.

### 2. Split the log line

- [This][split] article shows an approach to splitting lines.

### 3. Count the number of lines containing a password

- See [this discussion][multiple-matches] of multiple matches and [this][multi-line] on multi-line searches.

### 4. Remove artifacts from log

- [This article][replace] shows how text can be replaced.

### 5. List lines with extremely weak passwords so the guilty can be punished

- Capture groups are discussed [here][capture-groups].

[regular-expressions]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference
[regex]: https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=netcore-3.1
[ismatch]: https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch?view=netcore-3.1
[split]: https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.split?view=netcore-3.1
[multiple-matches]: https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.matches?view=netcore-3.1
[multi-line]: https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regexoptions?view=netcore-3.1
[replace]: https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.replace?view=netcore-3.1
[capture-groups]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/grouping-constructs-in-regular-expressions

## 1. Print a badge for an employee

- [String interpolation][string-interpolation] can be used to concisely format the badge.
- There is a [built-in method to convert a string to uppercase][toupper].

## 2. Print a badge for a new employee

- You should check if the ID is `null` before using it.
- [This tutorial goes into detail how to work with nullable value types][nullable-types-tutorial].

## 3. Print a badge for the owner

- You should check if the department is `null` before using it.
- [This tutorial goes into detail how to work with nullable reference types][nullable-reference-types-tutorial].
- The [null-conditional operator][null-conditional-operator] can be used to simplify calling a member on a nullable value.
- The [null-coalescing operator][null-coalescing-operator] can be used to simplify returning a different value if a nullable value is `null`.

[string-interpolation]: https://csharp.net-tutorials.com/operators/the-string-interpolation-operator/
[null-coalescing-operator]: https://csharp.net-tutorials.com/operators/the-null-coalescing-operator/
[null-conditional-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
[nullable-types-tutorial]: https://csharp.net-tutorials.com/data-types/nullable-types/
[nullable-reference-types-tutorial]: https://docs.microsoft.com/en-us/archive/msdn-magazine/2018/february/essential-net-csharp-8-0-and-nullable-reference-types
[toupper]: https://docs.microsoft.com/en-us/dotnet/api/system.string.toupper?view=netcore-3.1

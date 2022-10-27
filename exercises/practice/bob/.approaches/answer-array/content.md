# Answer array

```csharp
using System.Linq;

public static class Bob
{
    private static readonly string[] answers = {"Whatever.", "Sure.", "Whoa, chill out!", "Calm down, I know what I'm doing!"};
    
    public static string Response(string statement)
    {
        var input = statement.TrimEnd();
        if (input == "")
            return "Fine. Be that way!";

        var isShout = input.Any(c => char.IsLetter(c)) && input.ToUpper() == input ? 2: 0;
        
        var isQuestion = input.EndsWith('?') ? 1: 0;

        return answers[isShout + isQuestion];
    }
}
```

In this approach you define an array that contains Bob’s answers, and each condition is given a score.
The correct answer is selected from the array by using the score as the array index.

The `String` [TrimEnd][trimend] method is applied to the input to eliminate any whitespace at the end of the input.
If the string has no characters left, it returns the response for saying nothing.

```exercism/caution
Note that a `null` `string` would be different from a `string` of all whitespace.
A `null` `string` would throw an `Exception` if `TrimEnd` were applied to it.
To test a string that might be `null` or only whitespace, the [IsNullOrWhiteSpace](https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace) method of `String` would be used.
```

The first half of the shout condition 

```csharp

input.Any(c => char.IsLetter(c)) && input.ToUpper() == input
```

is constructed from the [Any][any] LINQ method and the [IsLetter][isletter] `Char` method to ensure there is at least one letter character in the `String`.
This is because the second half of the condition tests that the uppercased input is the same as the input.
If the input were only `"123"` it would equal itself uppercased, but without letters it would not be a shout.

The conditions of being a question and being a shout are assigned scores through the use of the [ternary operator][ternary].
For example, giving a question a score of `1` would use an index of `1` to get the element from the answers array, which is `"Sure."`.

| isShout | isQuestion | Index     | Answer                                |
| ------- | ---------- | --------- | ------------------------------------- |
| `false` | `false`    | 0 + 0 = 0 | `"Whatever."`                         |
| `false` | `true`     | 0 + 1 = 1 | `"Sure."`                             |
| `true`  | `false`    | 2 + 0 = 2 | `"Whoa, chill out!"`                  |
| `true`  | `true`     | 2 + 1 = 3 | `"Calm down, I know what I'm doing!"` |


## Shortening

When the body of an `if` statement is a single line, both the test expression and the body could be put on the same line, like so

```csharp
if (input == "") return "Fine. Be that way!";
```

The [C# Coding Conventions][coding-conventions] advise to write only one statement per line in the [layout conventions][layout-conventions] section,
but the conventions begin by saying you can use them or adapt them to your needs.
Your team may choose to overrule them.

For `Any`, the lambda expression of `c => char.IsLetter(c)` can be shortened to just the method call of `char.IsLetter` like so

```csharp
input.Any(char.IsLetter)
```

`Any` passes a single character in each iteration, and the `char.IsLetter` method is called on that character implicitly.
There is a detailed description of how it works in the accepted answer for this [StackOverflow question][method-group].

[trimend]: https://learn.microsoft.com/en-us/dotnet/api/system.string.trimend
[isnullorwhitespace]: https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace
[any]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any
[isletter]: https://learn.microsoft.com/en-us/dotnet/api/system.char.isletter
[ternary]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
[coding-conventions]: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
[layout-conventions]: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions#layout-conventions
[method-group]: https://stackoverflow.com/questions/35420610/passing-a-method-to-a-linq-query

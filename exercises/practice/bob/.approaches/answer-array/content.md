# Answer array

```csharp
    // uses System.Linq;
    private static readonly string[] answers = {"Whatever.", "Sure.", "Whoa, chill out!", "Calm down, I know what I'm doing!"};
    
    public static string Response(string statement)
    {
        var input = statement.TrimEnd();
        if (input == "") return "Fine. Be that way!";
        
        var isShout = (input.Any(c => char.IsLetter(c)) && input.ToUpper() == input) ? 2: 0;
        
        var isQuestion = (input.EndsWith('?')) ? 1: 0;
        
        return answers[isShout + isQuestion];
    }
```

An array can be defined that contains answers from which the right response is selected by an index calculated from scores given to the conditions.

The `String` [TrimEnd][trimend] method is applied to the input to eliminate any whitespace at the end of the input.
If the string has no characters left, it returns the response for saying nothing.
Note that a `null` `string` would be different from a `string` of all whitespace.
A `null` `string` would throw an `Exception` if `TrimEnd` were applied to it.
To test a string that might be `null` or only whitespace, the [IsNullOrWhiteSpace][isnullorwhitespace] method of `String` would be used.

The first half of the shout condition is constructed from the [Any][any] LINQ method and the [IsLetter][isletter] `Char` method to ensure there is at least one letter character in the `String`.
This is because the second half of the condition tests that the uppercased input is the same as the input.
If the input were only `"123"` it would equal itself uppercased, but without letters it would not be a shout.

The conditions of being a question and being a shout are assigned scores through the use of the [ternary operator][ternary].
For example, giving a queston a score of `1` would use an index of `1` to get the element from the answers array, which is `"Sure."`.


[trimend]: https://learn.microsoft.com/en-us/dotnet/api/system.string.trimend?view=net-7.0
[isnullorwhitespace]: https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace?view=net-7.0
[any]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any?view=net-7.0
[isletter]: https://learn.microsoft.com/en-us/dotnet/api/system.char.isletter?view=net-6.0
[ternary]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
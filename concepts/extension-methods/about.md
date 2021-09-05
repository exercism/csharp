# About

Extension methods allow adding methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type.

Extension methods are static methods, but they're called as if they were instance methods on the extended type. For client code, there's no apparent difference between calling an extension method and the methods defined in a type.

```csharp
public static int Sum(this IEnumerable<int> input)
{
    var sum = 0;
    foreach(int n in input)
    {
        sum += n;
    }
    return sum;
}

var sum = new int[]{1, 2, 3, 4}.Sum()
// sum == 10

public static int WordCount(this String str)
{
    return str.Split(new char[] { ' ', '.', '?' },
        StringSplitOptions.RemoveEmptyEntries
    ).Length;
}

int wordCount = "Hello World!".WordCount();
// wordCount == 2
```

A well-known example of extension methods are the LINQ standard query operators that add query functionality to the existing IEnumerable types.

[extension-methods]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods

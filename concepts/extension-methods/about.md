# About

[Extension methods][extension-methods] allow adding methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type.

Extension methods are static methods, but they're called as if they were instance methods on the extended type. It achieves this by using `this` before the type, indicating the instance we put the `.` on is passed as the first parameter. For client code, there's no apparent difference between calling an extension method and the methods defined in a type.

```csharp
public static int WordCount(this string str)
{
    return str.Split().Length;
}

"Hello World".WordCount();
// => 2
```

A well-known example of extension methods are the [LINQ][linq] standard query operators that add query functionality to the existing IEnumerable types.

[linq]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[extension-methods]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods

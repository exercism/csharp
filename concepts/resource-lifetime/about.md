We discussed in (TODO cross-ref-tba) how the `IDispoable` interface helps signal to callers of a class that there are resources or program state that need releasing or resetting in a timely fashion when the object in question is no longer required. In this exercise we have introduced some syntactic sugar, with the `using` keyword, that makes the code less verbose and less likely that significant calls will be omitted.

`using` can be seen as replacing [`try/finally`][try-finally] for some use cases.

```csharp
File file = null;
try
{
    file = new File("myStuff.txt");
    file.Write("more stuff");
}
finally
{
    file.Dispose();
}
```

This syntax is replaced with the more compact and foolproof:

```csharp
using (var file = new File("myStuff.txt")
{
    file.Write("more stuff");
}
```

Note that multiple resources can be conveniently combined following standard rules for single line blocks:

```csharp
using (var file = new File("mystuff.txt")
using (var fileWriter = new StreamWriter(file)
{
     ...
}
```

In C# 8 the following variation has been introduced where the `using` statement comes at the start of a block:

```csharp
using var file = new File("myStuff.txt");
file.Write("more stuff");
```

This allows you to have multiple disposable objects in the same block and to more naturally handle [`try/catch`][try-catch]:

```csharp
using var fileIn = new File("myStuff.txt");
using var fileOut = new File("yourStuff.txt");
try
{
    var stuff = fileIn.Read();
    fileOut.Write(stuff);
}
catch (Exception)
{
    LogStuff();
}
```

The rules related to how the `using` keyword can be used and with instances of what sort of types are detailed [here][using-statement].

#### Note for Java Developers

Java developers may recognize this as an analog of the [_automatic resource management_][automatic-resource-management] mechanism introduced in Java 7. They are very similar. Java's syntax, which repurposes `try` has the advantage of incorporating `catch` blocks more naturally than does C#'s `using`.

#### Versions

Note that the more flexible version of `using` where it does not have its own syntactic block was introduced in C# 8 so you may need to check if the code base you are working on is using C# 8 or later.

#### Reference

[using statement][using-statement] documentation describes how and when to use the `using` keyword.

[using-statement]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement
[automatic-resource-management]: https://docs.oracle.com/javase/tutorial/essential/exceptions/tryResourceClose.html
[try-finally]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-finally
[try-catch]: https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-use-the-try-catch-block-to-catch-exceptions

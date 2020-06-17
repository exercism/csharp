A user-defined exception is any class defined in your code that is derived from `System.Exception`. It is subject to all the rules of class inheritance but in addition the compiler and language runtime treat such classes in a special way allowing their instances to be thrown and caught outside the normal control flow as discussed in the `exceptions` exercise. User-defined exceptions can be used in every way like runtime and Microsoft Base Class Library exceptions.

This special treatment applies only to `Exception`-derived classes. You cannot throw instances of any other type.

User-defined exceptions are often used to carry extra information such as a message and other relevant data to be made available to the catching routines. This can then be recorded in logs, reported to a user or perhaps used in a retry operation. `System.Exception` has convenient data members and appropriate constructors to hold a message and the "inner" exception.

By convention exception class names end with "Exception", e.g. `MyTerribleException`.

Whilst using user-defined exceptions to wrap and enhance third party exceptions is a frequently seen pattern, the general advice is not to use them outside of this use case too liberally in your own code. It is considered an anti-pattern. There are challenges to this view and you can see both sides of the argument in this [Stack Exchange post][se-exceptions].

This [article][create-user-defined-exceptions] is a good introduction to user-defined exceptions.

As part of their guidance on [creating and throwing exceptions][exceptions-guidance] the .NET team recommend that user defined exceptions have a number of [convenience constructors][convenience-constructors]. For most purposes the combination illustrated below is appropriate.

```csharp
public class IncompleteExerciseException : System.Exception
{
    public IncompleteExerciseException() : base() { }
    public IncompleteExerciseException(string message) : base(message) { }
    public IncompleteExerciseException(string message, System.Exception inner) : base(message, inner) { }
}
```

## Exception Filters

`when` is the keyword in filtering exceptions. It is placed after the catch
statement and can take a boolean expression containing any values in scope at the time. They don't just have to be members of the exception itself. If the type of the exception matches and the expression evaluates to true then the block associated with that `catch` statement is executed otherwise the next `catch` statement, if any, is checked.

```csharp
try
{
    // do stuff
}
catch (Exception ex) when (ex.Message != "")
{
    // output the message when it is not empty
}
catch (Exception ex)
{
    // show stack trace or something.
}
```

- This [Exception filters][exception-filters] article shows how to filter exceptions.

[create-user-defined-exceptions]: https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions
[exception-filters]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/when
[se-exceptions]: https://softwareengineering.stackexchange.com/questions/189222/are-exceptions-as-control-flow-considered-a-serious-antipattern-if-so-why
[exceptions-guidance]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/exceptions/creating-and-throwing-exceptions
[convenience-constructors]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/exceptions/creating-and-throwing-exceptions#defining-exception-classes

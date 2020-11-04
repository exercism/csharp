Exceptions in C# provide a structured, uniform, and type-safe way of handling error conditions that occur during runtime. Proper handling of exceptions and error is important when trying to prevent application crashes.

In C#, all exceptions have `System.Exception` class as their base type. It contains important properties such as `Message`, which contains a human-readable description of the reason for the exception being thrown.

To signal that there should be an error in a certain part of the code, a new exception object needs to be created and then thrown,using the `throw` keyword:

```csharp
using System;
static int Square(int number)
{
    if (number >= 46341)
    {
        throw new ArgumentException($"Argument {number} cannot be higher than 46340 as its' square doesn't fit into int type.");
    }
    return number * number;
}
```

When an exception gets thrown, the runtime has the task of finding a piece of code that is responsible for handling of that exception. If no appropriate handler is found, the runtime displays the unhandled exception message in addition to stoping the execution of the program. To create a handler for an exception, C# uses the try-catch statement, which consists of a `try` block and one or more `catch` clauses. The `try` block should contain and guard code that may result in the exception getting thrown. The `catch` clauses should contain code that handles the behaviour of the program after the error has occured. It is important to note that the order of exceptions matters after the `try` block, as when multiple exceptions are listed, the first matching `catch` clause is executed.

```csharp
try
{
   if (number == -1)
   {
       throw new ArgumentException("The number cannot be equal to -1", "number");
   }

   if (number < 0)
   {
      throw new ArgumentOutOfRangeException("number", "The number cannot be negative");
   }

    // Process number ...
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine($"Number is out of range: {e.Message}");
}
catch (ArgumentException)
{
    Console.WriteLine($"Invalid number");
}
```

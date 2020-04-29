C# is a statically-typed language, which means that everything has a type at compile-time. Assigning a value to a name is referred to as defining a variable. A variable can be defined either by explicitly specifying its type, or by using the [`var` keyword][var] to have the C# compiler infer its type based on the assigned value.

```csharp
int explicitVar = 10; // Explicitly typed
var implicitVar = 10; // Implicitly typed
```

The value of a variable can be assigned and updated using the [`=` operator][assignment]. Once defined, a variable's type can never change.

```csharp
var count = 1; // Assign initial value
count = 2;     // Update to new value

// Compiler error when assigning different type
// count = false;
```

C# is an object-oriented language and requires all functions to be defined in a _class_, which are defined using the [`class` keyword][classes]. A function within a class is referred to as a _method_. Each [method][methods] can have zero or more parameters. All parameters must be explicitly typed, there is no type inference for parameters. Similarly, the return type must also be made explicit. Values are returned from functions using the [`return` keyword][return]. To allow a method to be called by code in other files, the `public` access modifier must be added.

```csharp
class Calculator
{
    public int Add(int x, int y)
    {
        return x + y;
    }
}
```

Invoking a method is done by specifying its class- and method name and passing arguments for each of the method's parameters.

```csharp
var sum = Calculator.Add(1, 2);
```

Arguments can optionally specify the corresponding parameter's name:

```csharp
var sum = Calculator.Add(x: 1, y: 2);
```

If the method to be called is defined in the same class as the method that calls it, the class name can be omitted.

If a method does not use any class _state_ (which is the case in this exercise), the method can be made _static_ using the `static` modifier. Similarly, if a class only has static methods, it too can be made static using the `static` modifier.

```csharp
static class Calculator
{
    public static int Multiply(int x, int y)
    {
        return x * y;
    }
}
```

Scope in C# is defined between the `{` and `}` characters.

C# supports two types of [comments][comments]. Single line comments are preceded by `//` and multiline comments are inserted between `/*` and `*/`.

Integer values are defined as one or more (consecutive) digits and support the [default mathematical operators][operators].

[assignment]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/assignment-operator
[var]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/var
[classes]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/classes#declaring-classes
[methods]: https://docs.microsoft.com/en-us/dotnet/csharp/methods
[return]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/return
[operators]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#addition-operator-
[comments]: https://www.w3schools.com/cs/cs_comments.asp

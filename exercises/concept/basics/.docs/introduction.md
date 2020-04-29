C# is a statically-typed language, which means that everything has a type at compile-time. Assigning a value to a name is referred to as defining a variable. A variable can be defined either by explicitly specifying its type, or by letting the C# compiler infer its type based on the assigned value (known as _type inference_). Therefore, the following two variable definitions are equivalent:

```csharp
int explicitVar = 10; // Explicitly typed
var implicitVar = 10; // Implicitly typed
```

Updating a variable's value is done through the `=` operator. Once defined, a variable's type can never change.

```csharp
var count = 1; // Assign initial value
count = 2;     // Update to new value

// Compiler error when assigning different type
// count = false;
```

C# is an [object-oriented language][object-oriented-programming] and requires all functions to be defined in a _class_. The `class` keyword is used to define a class.

```csharp
class Calculator
{
    // ...
}
```

A function within a class is referred to as a _method_. Each method can have zero or more parameters. All parameters must be explicitly typed, there is no type inference for parameters. Similarly, the return type must also be made explicit. Values are returned from functions using the `return` keyword. To allow a method to be called by code in other files, the `public` access modifier must be added.

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

Scope in C# is defined between the `{` and `}` characters.

C# supports two types of comments. Single line comments are preceded by `//` and multiline comments are inserted between `/*` and `*/`.

[object-oriented-programming]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/object-oriented-programming

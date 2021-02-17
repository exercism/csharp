# About

C# is a statically-typed language, which means that everything has a type at compile-time. Choosing a name for a [variable][variable] is referred to as defining a variable. Once a variable is defined, setting or updating a value is called variable assignment. A variable can be defined either by explicitly specifying its type, or by using the [`var` keyword][var] to have the C# compiler infer its type based on the assigned value. The use of `var` is known as _type inference_.

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

C# is an object-oriented language and requires all [functions][function] to be defined in a _class_, which are defined using the [`class` keyword][classes]. Objects (or _instances_) are created by using the `new` keyword.

```csharp
class Calculator
{
    // ...
}

var calculator = new Calculator();
```

A function within a class is referred to as a _method_. Each [method][methods] can have zero or more parameters. All parameters must be explicitly typed, there is no type inference for parameters. Similarly, the return type must also be made explicit. Values are returned from methods using the [`return` keyword][return]. To allow a method to be called by code in other files, the `public` access modifier must be added.

```csharp
class Calculator
{
    public int Add(int x, int y)
    {
        return x + y;
    }
}
```

Methods are invoked using dot (`.`) syntax on an instance, specifying the method name to call and passing arguments for each of the method's parameters. Arguments can optionally specify the corresponding parameter's name.

```csharp
var calculator = new Calculator();
var sum_v1 = calculator.Add(1, 2);
var sum_v2 = calculator.Add(x: 1, y: 2);
```

If the method to be called is defined in the same class as the method that calls it, the class name can be omitted.

If a method does not use any object _state_, the method can be made _static_ using the `static` modifier. Static methods are also invoked using dot (`.`) syntax, but are invoked on the class itself instead of an instance of the class.

If a class only has static methods, it too can be made static using the `static` modifier. This expresses the intention of the class.

```csharp
static class Calculator
{
    public static int Multiply(int x, int y)
    {
        return x * y;
    }
}

Calculator.Multiply(2, 4); // => 8
```

Scope in C# is defined between the `{` and `}` characters.

C# supports two types of [comments][comments]. Single line comments are preceded by `//` and multiline comments are inserted between `/*` and `*/`.

Integer values are defined as one or more (consecutive) digits and support the [default mathematical operators][operators].

A variable name [must follow some rules][identifier-names] like starting either by a letter or an underscore, and [should follow C# naming convention][naming-guidelines]. If a variable name collides with a reserved [C# keyword][csharp-keywords], it must be escaped using `@`. Use of that notation is not recommended, but it can be encountered in exceptional cases, for example: `var @this`, `var @class` or `var @var`.

There are a couple of concepts that are so fundamental to a C-family language like C# that they occur naturally in almost any piece of non-trivial code. These are [mutation][mutation] and [scope][scope]. Mutation is the idea that a variable can have its value changed in the course of a program's lifetime. Scope is the idea that the value associated with a name (of a program element) is only accessible within the code "area" where it is defined. The principal code areas in C# are _class/struct_ and _function_ (typically methods) but can also include the bodies of loops and other constructs.

[assignment]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/assignment-operator
[var]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/var
[classes]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/classes#declaring-classes
[methods]: https://docs.microsoft.com/en-us/dotnet/csharp/methods
[return]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/return
[operators]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#addition-operator-
[comments]: https://www.w3schools.com/cs/cs_comments.asp
[identifier-names]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/identifier-names
[naming-guidelines]: https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-guidelines
[csharp-keywords]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/
[variable]: https://www.guru99.com/c-sharp-variables-operator.html
[function]: https://csharp.net-tutorials.com/classes/methods/
[mutation]: https://benmccormick.org/2016/06/04/what-are-mutable-and-immutable-data-structures-2
[scope]: https://www.geeksforgeeks.org/scope-of-variables-in-c-sharp/

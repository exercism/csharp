# About

Lambdas are functions without a name. They are basically a shorthand notation for functions.

Lambdas can be either [expression lambdas](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions) or [statement lambdas](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions#statement-lambdas):

```
(input_parameters) => expression
(input_parameters) => { <statements> }
```

## Declaring lambdas

Lambdas that return no value (`void`) can be converted to an `Action<T>` delegate type.

```csharp
// Statement lambda
Action = () =>
{
    Console.WriteLine("No parameters");
    Console.WriteLine("Still nice, right?");
}

// Expression lambda
Action<int> = (x) => Console.WriteLine(x);
```

Lambdas with a non-void return value can be converted to a `Func<T>` delegate type.

```csharp
// Expression lambda
Func<int, int> = (x) => x * x;

// Statement lambda
Func<string, string, bool> = (left, right) =>
{
    var equal = left == right;
    return equal;
}
```

If a lambda has only a single parameter, the parentheses around the parameter can be omitted:

```csharp
// Equivalent definitions
Action<int> = (x) => Console.WriteLine(x);
Action<int> = x => Console.WriteLine(x);
```

## Lambda arguments

The primary use of lambdas is in passing them as arguments to other methods, such as most LINQ methods:

```csharp
var numbers = new[] { 1, 2, 3, 4 };
var doubled = numbers.Select(n => n * 2);
foreach (var number in doubled)
{
    Console.Write(number)
}
// => 2468
```

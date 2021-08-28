# Introduction

Methods can have a varargs parameter which allows the caller to specify zero or more arguments like they were regular parameters. The method will receive these arguments in a single array.

To make a parameter a varargs parameter, add the `params` keyword to the parameter declaration:

```csharp
public static void PrintNumbers(params int[] numbers)
{
    foreach (var number in numbers)
    {
        Console.Write(number)
    }
}

// No values for a varags parameter is allowed
PrintNumbers();

PrintNumbers(1);
// => 1

PrintNumbers(1, 2, 3);
// => 123
```

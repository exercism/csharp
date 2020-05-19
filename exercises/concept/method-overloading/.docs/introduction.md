_Method overloading_ allows multiple methods in the same class to have the same name. Overloaded methods must be different from each other by either:

- The number of parameters
- The type of the parameters

There is no method overloading based on the return type.

The compiler will automatically infer which overloaded method to call based on the number of parameters and their type.

A method parameter can be made optional by assigning it a default value. When calling a method with optional parameters, the caller is not required to pass a value for them. If no value is passed for an optional parameter, its default value will be used.

Optional parameters _must_ be at the end of the parameter list; they cannot be followed by non-optional parameters.

```csharp
class Card
{
    static string NewYear(int year = 2020)
    {
        return $"Happy {year}!";
    }
}

Card.NewYear();  // => "Happy 2020!"
Card.Card(1999); // => "Happy 1999!"
```

# Introduction

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

Card.NewYear();     // => "Happy 2020!"
Card.NewYear(1999); // => "Happy 1999!"
```

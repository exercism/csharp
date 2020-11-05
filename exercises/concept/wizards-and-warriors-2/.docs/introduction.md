## method-overloading

_Method overloading_ allows multiple methods in the same class to have the same name. Overloaded methods must be different from each other by either:

- The number of parameters
- The type of the parameters

There is no method overloading based on the return type.

The compiler will automatically infer which overloaded method to call based on the number of parameters and their type.

## optional-parameters

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

## named-arguments

So far we have seen that the arguments passed into a method are matched to the method are matched to the method's declared parameters based on position. An alternative approach, particularly where a routine takes a large number of arguments, the caller can match arguments by specifying the declared parameter's identifier.

The following illustrates the syntax:

```csharp
class Card
{
    static string NewYear(int year, int month, int day)
    {
        return $"Happy {year}-{month}-{day}!";
    }
}

Card.NewYear(month: 1, day: 1, year: 2020);  // => "Happy 2020-1-1!"
```

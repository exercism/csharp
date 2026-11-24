# Introduction

So far we have seen that the arguments passed into a method are matched to the method's declared parameters based on position.
An alternative approach is for the caller to match arguments by specifying the declared parameter's identifier.
This is particularly useful where a routine takes a large number of arguments.

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

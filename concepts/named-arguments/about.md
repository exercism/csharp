# About

If a method has multiple optional parameters, you can specify only some of them using [named arguments][named-arguments].

```csharp
class Card
{
    static string NewYear(int year = 2020, string sender = "me")
    {
        return $"Happy {year} from {sender}!";
    }
}

Card.NewYear();  // => "Happy 2020 from me!"
Card.Card(1999); // => "Happy 1999 from me!"
Card.Card(sender: "mom"); // => "Happy 2020 from mom!"
```

[named-arguments]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments#named-arguments

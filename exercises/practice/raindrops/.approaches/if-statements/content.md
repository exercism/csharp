# `if` statements

```csharp
public static class Raindrops
{
    public string ConvertWithIfConcat()
    {
        var drops = "";
        if (number % 3 == 0)
            drops += "Pling";
        if (number % 5 == 0)
            drops += "Plang";
        if (number % 7 == 0)
            drops += "Plong";
        return drops.Length > 0 ? drops.ToString() : number.ToString();
    }
}
```

## Shortening

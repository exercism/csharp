The C# `enum` type represents a fixed set of named constants (an enumeration). Its chief purpose is to provide a type-safe way of interacting with numeric constants, limiting the available values to a pre-defined set. A simple enum can be defined as follows:

```csharp
enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}
```

If not defined explicitly, enum members will automatically get assigned incrementing integer values, with the first value being zero. It is also possible to assign values explicitly:

```csharp
enum Answer
{
    Maybe = 1,
    Yes = 3,
    No = 5
}
```

In C#, the `null` literal is used to denote the absence of a value. A _nullable_ type is a type that allows for `null` values.

Prior to C# 8.0, reference types were always nullable and value types were not. A value type can be made nullable though by appending it with a question mark (`?`).

```csharp
string nullableReferenceType = "hello";
nullableReferenceType = null; // Valid as type is nullable

int nonNullableValueType = 5;
nonNullableValueType = null; // Compile error as type is not nullable

int? nullableValueType = 5; // Define nullable value type
nullableValueType = null;   // Valid as type is nullable
```

Accessing a member of a variable which value is `null` will compile fine, but result in a `NullReferenceException` being thrown at runtime:

```csharp
string sentence = null;

// Throws NullReferenceException at runtime
sentence.Length;
```

To counter this common type of mistake, C# 8 allows one to opt-into a feature that makes reference types non-nullable by default:

```csharp
string nonNullableReferenceType = "book";
nonNullableReferenceType = null; // Compile warning (no error!)

string? nullableReferenceType = "movie";
nullableReferenceType = null; // Valid as type is nullable
```

To safely work with nullable values, one should check if they are `null` before working with them:

```csharp
string NormalizedName(string? name)
{
    if (name == null)
    {
        return "UNKNOWN";
    }
    else
    {
        // Value is not null at this point, so no compile warning
        // and no runtime NullReferenceException being thrown
        return name.ToUpper();
    }
}

NormalizedName(null); // => "UNKNOWN"
NormalizedName("Elisabeth"); // => "ELISABETH"
```

The `??` operator allows one to return a default value when the value is `null`:

```csharp
string? name1 = "John";
name1 ?? "Paul"; // => "John"

string? name2 = null;
name2 ?? "George"; // => "George"
```

The `?.` operator allows one to call members safely on a possibly `null` value:

```csharp
string? fruit = "apple";
fruit?.Length; // => 5

string? vegetable = null;
vegetable?.Length; // => null
```

[nullable-csharp-8]: https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references

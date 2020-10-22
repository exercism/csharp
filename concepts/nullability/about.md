In C#, the [`null` literal][null-keyword] is used to denote the absence of a value. A _nullable_ type is a type that allows for `null` values.

Prior to C# 8.0, reference types were always nullable and value types were not. A [value type can be made nullable][nullable-value-types] though by appending it with a question mark (`?`).

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
string sentence = "What a nice day!";

// Throws NullReferenceException at runtime
sentence.Length;
```

To counter this common type of mistake, C# 8 allows one to [opt-into a feature][nullable-csharp-8] that makes [reference types non-nullable by default][nullable-reference-types]:

```csharp
string nonNullableReferenceType = "book";
nonNullableReferenceType = null; // Compile warning (no error!)

string? nullableReferenceType = "movie";
nullableReferenceType = null; // Valid as type is nullable
```

To [safely work with nullable values][nullable-types-tutorial], one should check if they are `null` before working with them:

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

The [`??` operator][null-coalescing-operator] allows one to return a default value when the value is `null`:

```csharp
string? name1 = "John";
name1 ?? "Paul"; // => "John"

string? name2 = null;
name2 ?? "George"; // => "George"
```

The [`?.` operator][null-conditional-operator] allows one to call members safely on a possibly `null` value:

```csharp
string? fruit = "apple";
fruit?.Length; // => 5

string? vegetable = null;
vegetable?.Length; // => null
```

If the compiler thinks a value could be `null` but you are certain it won't be, the [`!.` operator][null-forgiving-operator] can be used to suppress the warning. Only use this operator as a last resort though.

```csharp
void PrintName(string? name)
{
    // Assume that the IsValid() method only return true
    // when its argument is not null
    if (IsValid(name))
    {
        // No compile warning
        Console.WriteLine(name!.Length);
    }
}
```

If you'd like to learn more about working with nullable reference, check out [this tutorial][nullable-reference-types-tutorial].

[nullable-csharp-8]: https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references
[null-keyword]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null
[nullable-types-tutorial]: https://csharp.net-tutorials.com/data-types/nullable-types/
[nullable-reference-types]: https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references
[nullable-value-types]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types
[nullable-csharp-8]: https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references
[null-forgiving-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-forgiving
[null-coalescing-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
[null-conditional-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-
[nullable-reference-types-tutorial]: https://docs.microsoft.com/en-us/archive/msdn-magazine/2018/february/essential-net-csharp-8-0-and-nullable-reference-types

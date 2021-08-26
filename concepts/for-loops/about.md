# About

A [`for` loop][for-statement] allows one to repeatedly execute code in a loop until a condition is met.

```csharp
for (int i = 0; i < 5; i++)
{
    System.Console.Write(i);
}

// => 01234
```

A `for` loop consists of four parts:

1. The initializer: executed once before entering the loop. Usually used to define variables used within the loop.
2. The condition: executed before each loop iteration. The loop continues to execute while this evaluates to `true`.
3. The iterator: execute after each loop iteration. Usually used to modify (often: increment/decrement) the loop variable(s).
4. The body: the code that gets executed each loop iteration.

## for vs foreach loops

In general [concept:csharp/foreach-loops]() are preferrable over `for` loops for the following reasons:

- A `foreach` loop is guaranteed to iterate over _all_ values. With a `for` loop, it is easy to miss elements, for example due to an off-by-one error.
- A `foreach` loop is more _declarative_, your code is communicating _what_ you want it to do, instead of a `for` loop that communicates _how_ you want to do it.
- A `foreach` loop is foolproof, whereas with `for` loops it is easy to have an off-by-one error.
- A `foreach` loop works on all collection types, including those that don't support using an indexer to access elements.

To guarantee that a `foreach` loop will iterate over _all_ values, the compiler will not allow updating of a collection within a `foreach` loop:

```csharp
char[] vowels = new [] { 'a', 'e', 'i', 'o', 'u' };

foreach (char vowel in vowels)
{
    // This would result in a compiler error
    // vowel = 'Y';
}
```

A `for` loop does have some advantages over a `foreach` loop:

- You can start or stop at the index you want.
- You can use any (boolean) termination condition you want.
- You can skip elements by customizing the incrementing of the loop variable.
- You can process collections from back to front by counting down.
- You can use `for` loops in scenarios that don't involve collections.

[implicitly-typed-arrays]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/implicitly-typed-arrays
[array-foreach]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/using-foreach-with-arrays
[single-dimensional-arrays]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/single-dimensional-arrays
[array-class]: https://docs.microsoft.com/en-us/dotnet/api/system.array?view=netcore-3.1
[array-properties]: https://docs.microsoft.com/en-us/dotnet/api/system.array?view=netcore-3.1#properties
[array-methods]: https://docs.microsoft.com/en-us/dotnet/api/system.array?view=netcore-3.1#methods
[foreach-statement]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/foreach-in
[for-statement]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/for
[break-keyword]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/break
[multi-dimensional-arrays]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays
[system-array-object]: https://docs.microsoft.com/en-us/dotnet/api/system.array.createinstance?view=netcore-3.1#System_Array_CreateInstance_System_Type_System_Int32_

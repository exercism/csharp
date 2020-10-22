TODO: about.md files and links.json files are the same for arrays, for-loops and foreach. Consider how to prise these apart of otherwise treat these closely coupled concepts.
Data structures that can hold zero or more elements are known as _collections_. An **array** is a collection that has a fixed size/length and whose elements must all be of the same type. Elements can be assigned to an array or retrieved from it using an index. C# arrays are zero-based, meaning that the first element's index is always zero:

```csharp
// Declare array with explicit size (size is 2)
int[] twoInts = new int[2];

// Assign second element by index
twoInts[1] = 8;

// Retrieve the second element by index
twoInts[1] == 8; // => true

// Check the length of the array
twoInts.Length == 2; // => true
```

Arrays can also be defined using a shortcut notation that allows you to both create the array and set its value. As the compiler can now tell how many elements the array will have, the length can be omitted:

```csharp
// Three equivalent ways to declare and initialize an array (size is 3)
int[] threeIntsV1 = new int[] { 4, 9, 7 };
int[] threeIntsV2 = new[] { 4, 9, 7 };
int[] threeIntsV3 = { 4, 9, 7 };
```

Arrays can be manipulated by either calling an array instance's [methods][array-methods] or [properties][array-properties], or by using the static methods defined in the [`Array` class][array-class].

An array is also a _collection_, which means that you can iterate over _all_ its values using a [`foreach` loop][foreach-statement]:

```csharp
char[] vowels = new [] { 'a', 'e', 'i', 'o', 'u' };

foreach (char vowel in vowels)
{
    // Output the vowel
    System.Console.Write(vowel);
}

// => aeiou
```

One could use a [`for` loop][for-statement] to iterate over an array:

```csharp
char[] vowels = new [] { 'a', 'e', 'i', 'o', 'u' };

for (int i = 0; i < vowels.Length; i++)
{
    // Output the vowel
    System.Console.Write(vowels[i]);
}

// => aeiou
```

However, generally a `foreach` loop is preferrable over a `for` loop for the following reasons:

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

Related Topics:

- You should be aware that C# supports [multi-dimensional arrays][multi-dimensional-arrays] like `int[,] arr = new int[10, 5]` which can be very useful.
- You should also be aware that you can instantiate objects of type [`System.Array`][system-array-object] with `Array.CreateInstance`. Such objects are of little use - mainly for interop with VB.NET code. They are not interchangeable with standard arrays (`T[]`). They can have a non-zero lower bound.

Both the above topics are discussed more fully in a later exercise.

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

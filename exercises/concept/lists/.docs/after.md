Lists in C# are collections of primitive values or instances of structs or classes. They are implemented in the base class library as [`List<T>`][lists-docs] where `T` is the type of the item in the list. The API exposes a rich set of methods for creating and manipulating lists.

```csharp
var listOfStrings = new List<string>();
var listOfIntegers = new List<int>();
var listOfRandoms = new List<Random>();
var listOfBigIntegers = new List<BigInteger>();
```

A collection definition typically includes a place holder in angle brackets, often `T` by convention. This allows the collection user to specify what type of items to store in the collection.

Unlike arrays (TODO cross-ref-tba) lists can resize themselves dynamically.

#### Generic classes

Lists are an example of generic classes. You will also see `HashSet<T>` and `Dictionary<T>` in early exercises.

More [advanced generic techniques][generics] are discussed in (TODO cross-ref-tba) including creating your own generics.

If you need a list of different types then you can use `List<Object>` but you will need to [down cast][casting] elements that you access in from the list.

You should also be aware of `System.Collections.List` which you may encounter in legacy code. To all intents and purposes this behaves like `List<Oject>`.

#### LINQ

Although the built-in API of `List<T>` is rich (including mappings and filters such as `ConvertAll`, `FindAll` and `Foreach`) and its [looping syntax][for-each] is very clear, and you definitely need to be familiar with this API, Language Integrated Query ([LINQ][linq]) is available for many tasks, is even more powerful and widely used and has the advantage of providing a consistent interface across library collections, third-party collections and your own classes. See (TODO cross-ref-tba).

#### Reference

- [List documentation][lists-docs]: reference documentation for `List<T>`.
- [Lists tutorial][lists-tutorial]: basic tutorial on how to work with lists.

[lists-docs]: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netcore-3.1
[lists-tutorial]: https://csharp.net-tutorials.com/collections/lists/
[generics]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/
[casting]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/casting-and-type-conversions
[linq]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[for-each]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/foreach-in

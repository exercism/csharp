Lists are an example of generic classes. You will also see `HashSet<T>` and `Dictionary<T>` in early exercises.

More [advanced generic techniques][generics] are discussed in (TODO cross-ref-tba) including creating your own generics.

If you need a list of different types then you can use `List<Object>` but you will need to [down cast][casting] elements that you access in from the list.

You should also be aware of `System.Collections.List` which you may encounter in legacy code. To all intents and purposes this behaves like `List<Oject>`.

[generics]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/
[casting]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/casting-and-type-conversions

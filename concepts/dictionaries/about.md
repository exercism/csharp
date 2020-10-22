Dictionaries, like their equivalents in other languages such as maps or associative arrays, store key/value pairs such that a value can be retrieved or changed directly by passing the key to the dictionary's indexer property.

In addition key/value pairs can be added and removed from the dictionary. Keys, values and key/value pairs can be enumerated.

Values can be objects of any C# type, which includes primitives, structs _and_ classes.

The Dictionary object allows keys to be objects of any type. However to ensure correct behavior at runtime keys must have an appropriate hashcode as returned by [GetHashCode][gethashcode].

A dictionary instance cannot be safely accessed by more than one thread (not thread-safe). [ConcurrentDictionary][concurrent-dictionary] is available for multi-threading situations.

See also [HashSet][hashset], [ConcurrentDictionary][concurrent-dictionary], [SortedDictionary][sorted-dictionary].

Whilst there is no non-generic version of Dictionary a number of classes remain in the library to support a non-generic map. You need to be aware of the non-generic IDictionary and Hashtable mainly so that you know them when you see them. It is unlikely you would have to use them other than in maintaining an old code base.

You will often want to expose and access the dictionary by its [`IDictionary<TKey, TValue>`][idictionary] interface.

Note that because of the nature of [indexer properties][indexer-properties] primitive values can be modified in place, such as:

```csharp
nums["some-number"] = 3;
nums["some-number"]++;
// nums["some-number"] == 4

```

[concurrent-dictionary]: https://docs.microsoft.com/en-gb/dotnet/api/system.collections.concurrent.concurrentdictionary-2?view=netcore-3.1
[hashset]: https://docs.microsoft.com/en-gb/dotnet/api/system.collections.generic.hashset-1?view=netcore-3.1
[gethashcode]: https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netcore-3.1
[sorted-dictionary]: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2?view=netcore-3.1
[idictionary]: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2?view=netcore-3.1
[indexer-properties]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/

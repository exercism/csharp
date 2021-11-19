# About

While the `readonly` modifier prevents the value or reference in a field from being overwritten, it offers no protection for the members of a reference type.

```csharp
readonly List<int> ints = new List<int>();

void Foo()
{
    ints.Add(1);    // ok
    ints = new List<int>(); // fails to compile
}
```

To ensure that all members of a reference type are protected the fields can be made `readonly` and automatic properties can be defined without a `set` accessor.

The Base Class Library (BCL) provides some readonly versions of collections where there is a requirement to stop members of a collections being updated. These come in the form of wrappers:

- [`ReadOnlyDictionary<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.readonlydictionary-2?view=net-6.0) exposes a `Dictionary<T>` as read-only.
- [`ReadOnlyCollection<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.readonlycollection-1?view=net-6.0) exposes a `List<T>` as read-only.

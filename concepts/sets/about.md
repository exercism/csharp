# About

A set is a collection of unique values. The default .NET implementation of a set is the [`HashSet<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1

The `HashSet` class uses each element's [`GetHashCode()` method](https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode

By default, the `GetHashCode()` implementation for reference types returns a hash of its memory location. This means that different reference type objects will have a different hash code (this is known as reference equality). Value types by default return a hash of their fields/properties. This means that different value type objects with the same field/property values will have the same hash code (this is known as structural equality).

You can override the `GetHashCode()` implementation on your own classes, which you could use to have a reference type have structural equality.

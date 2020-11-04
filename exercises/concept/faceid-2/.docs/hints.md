### General

- [Equality][equality]: how equality comparisons work in C#, including reference- and value type equality.
- [HashCode][hash-code]: how to create and combine hash codes
- [GetHashCode][get-hash-code]: API documentation
- [HashSet][hash-set]: API documentation

## 1. Ensure that facial features match

Comparing reference types by value is discussed in detail in this [article][value-equality].

## 2. Authenticate the system administrator

This is simply a case of applying the lessons learnt in task 1 in a trivially recursive manner.

## 3. Register new identities

The most performant, and "natural", way to handle a collection of unique values is by using a [hash set][hash-set].

## 4. Prevent invalid identities being authenticated

Consider the [`HashSet<T>.Contains()`][hash-set-contains] method.

## 5. Add diagnostics to detect multiple attempts to authenticate

This [documentation][reference-equality] addresses the issue of comparing instances as opposed to values.

[equality]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/equality-comparisons
[hash-set]: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?view=netcore-3.1
[hash-code]: https://docs.microsoft.com/en-us/dotnet/api/system.hashcode?view=netcore-3.1
[get-hash-code]: https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netcore-3.1
[reference-equality]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/equality-comparisons#reference-equality
[value-equality]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type
[hash-set-contains]: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1.contains?view=netcore-3.1

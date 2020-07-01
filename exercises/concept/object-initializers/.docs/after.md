Object initializers are an alternative to constructors. The syntax is a comma separated list of field name=value pairs, illustrated below:

```csharp
public class Person
{
    public string Name;
    public string Address;
}

var person = new Person{Name="The President", Address = "Élysée Palace"};
```

Collections can also be initialized in this way. Typically, this is accomplished with comma separated lists as shown here:

```csharp
IList<Person> people = new List<Person>{ new Person(), new Person{Name="Joe Shmo"}};
```

This approach (and syntax) can be used with any class that implements `IEnumerable` and has an `Add()` method.

Fields can be listed in any order or ommitted completely.

Dictionaries use the following syntax:

```csharp
IDictionary<int, string> numbers = new Dictionary<int, string>{ [0] = "zero", [1] = "one"...};

// or

IDictionary<int, string> numbers = new Dictionary<int, string>{ {0, "zero" }, {1,  "one"}...};
```

The initialized fields must be accessible to the caller. Typically, this means they must be `public` or `internal`.

There is a strong trend promoting immutability amongst the language designers and leading practitioners, so the mutability of objects initialized in this way is seen as a disadvantage. There are proposals to introduce an `init` clause in the upcoming version of the language, C# 9, which may address this.

- [object initializer][object-initializers] documentation describes how to use initialzers.
- [collection initializer][collection-initializers] documentation gives a preview of how initializers can be used with collections like dictionaries and lists.

[object-initializers]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#object-initializers
[collection-initializers]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#collection-initializers

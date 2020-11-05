## lists

Lists in C# are collections of primitive values or instances of structs or classes. They are implemented in the base class library as `List<T>` where `T` is the type of the item in the list. The API exposes a rich set of methods for creating and manipulating lists.

Items can be added to and removed from lists. They grow and shrink as necessary.

```csharp
var listOfStrings = new List<string>();
```

## generic-types

A collection definition typically includes a place holder in angle brackets, often `T` by convention. Such a collection is referred to as a generic type. This allows the collection user to specify what type of items to store in the collection. In the above example code we are instantiating a list of strings.

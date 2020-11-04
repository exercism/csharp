The `const` modifier can be (and generally should be) applied to any field where its value is known at compile time and will not change during the lifetime of the program.

```csharp
private const int num = 1729;
public const string title = "Grand" + " Master";
```

The `readonly` modifier can be (and generally should be) applied to any field that cannot be made `const` where its value will not change during the lifetime of the program and is either set by an inline initializer or during instantiation (by the constructor or a method called by the constructor).

```csharp
private readonly int num;
private readonly System.Random rand = new System.Random();

public MyClass(int num)
{
    this.num = num;
}
```

#### Read-only collections

Although the `readonly` modifier prevents the value or reference in a field from being overwritten, the modifier provides no protection for the members of a reference type.

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

- `ReadOnlyDictionary<T>` exposes a `Dictionary<T>` as read-only.
- `ReadOnlyCollection<T>` exposes a `List<T>` as read-only.

#### Defensive copying

In security sensitive situations (or even simply on a large code-base where developers have different priorities and agendas) you should avoid allowing a class's public API to be circumvented by accepting and storing a method's mutable parameters or by exposing a mutable member of a class through a return value or as an `out` parameter.

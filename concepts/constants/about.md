#### const

The [`const`][constants] modifier can be (and generally should be) applied to any field where its value is known at compile time and will not change during the lifetime of the program.

```csharp
private const int num = 1729;
public const string title = "Grand" + " Master";
```

The compiler will guide you as to what expressions can be evaluated at compile-time. Simple arithmetic operations are allowed as is string concatenation. This excludes any evaluation that would require use of the heap or stack so all method calls and references to non-primitive types are not available.

There is some discussion on the web about the performance advantages of `const` over variables. In the case of a comparison with instance non-const fields there could be a noticeable saving in memory but compared to static variables that is decidedly trivial. Any consideration of CPU performance is likely to be seen by your colleagues as [premature optimization][premature-optimization].

A more compelling reason to use `const` is that it enhances a maintainer's ability to reason about the code. Glimpsing that a field is marked as `const` or `readonly` or that a property has no setter allows the maintainer largely to dismiss it from their analysis. It is unlikely to be the seat of bugs. It is unlikely to pose difficulties in a refactoring exercise. This [Stack Overflow comment][so-consts] addresses this.

The `const` modifier can also be applied to values within methods:

```csharp
public double Area(double r)
{
    const double π = 3.142;
    return System.Math.Pow((π * r), 2);
}
```

Identifying a value with `const` in this way can be useful if it is used multiple times in the method or you want to draw attention to its meaning. There is no performance gain over using literals inline.

#### readonly

The [`readonly`][readonly-fields] modifier can be (and generally should be) applied to any field that cannot be made `const` where its value will not change during the lifetime of the program and is either set by an inline initializer or during instantiation (by the constructor or a method called by the constructor).

```csharp
private readonly int num;
private readonly System.Random rand = new System.Random();

public MyClass(int num)
{
    this.num = num;
}
```

Use of the `readonly` modifier is encouraged for the same reasons that apply to `const`. The practice of constraining fields in this way helps maintainers reason about the code.

Note that adding the `readonly` modifier to a field prevents only the value of the field from being changed. In the case of aggregate types it does not protect the fields or properties of that type. In particular, it does not protect the contents of arrays.

```csharp
private readonly IList list = new List();

public void Foo()
{
    list = new List();  // does not compile

    list.Add("new stuff");  // succeeds at runtime
}
```

To ensure that all members of a reference type are protected the fields can be made `readonly` and automatic properties can be defined without a `set` accessor.

You should examine [read-only collections][readonly-collections] in the Base Class Library.

For arrays the closest you can get to a read-only version is the [`Array.AsReadOnly<T>()][as-read-only] method.

[readonly-fields]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly#readonly-field-example
[constants]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constants
[so-consts]: https://stackoverflow.com/a/5834473/96167
[premature-optimization]: https://wiki.c2.com/?PrematureOptimization
[as-read-only]: https://docs.microsoft.com/en-us/dotnet/api/system.array.asreadonly?view=netcore-3.1
[readonly-collections]: https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.readonlycollection-1?view=netcore-3.1

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

Casting and type conversion are different ways of changing an expression from one data type to another.

An expression can be cast to another type with the cast operator `(<type>)`.

```csharp
long l = 1000L;
int i = (int)l;

object o = new Random();
Random r = (Random)o;
```

If the types are not compatible an instance of `InvalidCastException` is thrown. In the case of numbers this indicates that the receiving type cannot represent the cast value. In the case of classes, one of the types must be derived from the other (this also applies trivially to structs).

An alternative to _casting_ is _type conversion_ using the `is` operator. This is typically applied to reference and nullable types.

```csharp
object o = new Random();
if (o is Random rand)
{
    int ii = rand.Next();
    // now, do something random
}
```

If you need to detect the precise type of an object then `is` may be a little too permissive as it will return true for a class and any of the classes and interfaces from which it is derived directly or indirectly. `typeof` and `Object.GetType()` are the solution in this case.

```csharp
object o = new List<int>();

o is ICollection<int> // true
o.GetType() == typeof(ICollection<int>) // false
o is List<int> // true
o.GetType() == typeof(List<int>) // true
```

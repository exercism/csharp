C# types can be defined within the scope of a class or struct. The enclosing type provides a kind of name space. Access to the type is through the enclosing type with dot syntax.

```csharp
class Outer
{
    public interface IInner {}
    public enum EInner {}
    public class CInner {}
    public struct SInner {}
}

var outer = new Outer();
var inner = new Outer.CInner();
```

You can set access levels for inner types.

Private members of the outer type are in scope for members of the inner type but not vice versa.

# Introduction

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

In order to access members of the containing type simply hand over an containing type to the inner type's constructor. Private members of the outer type are in scope for members of the inner type but not vice versa.

```csharp
public class Outer
{
    public class CInner
    {
        private Outer parent;

        public CInner(Outer parent) {
            this.parent = parent
        }
    }
}
```

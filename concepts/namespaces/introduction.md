Namespaces are a way to group related code and to avoid name clashes and are generally present in all but the most trivial code base.

The syntax is as follows:

```csharp
namespace MyNameSpace
{
    public class MyClass {}

    public class OtherClass {}
}
```

Types enclosed in namespaces are referred to outside the scope of the namespace by prefixing the type name with the dot syntax. Alternatively, and more usually, you can place a `using` directive at the top of the file (or within a namespace) and type can be used without the prefix. Within the same namespace there is no need to qualify type names.

```csharp
namespace MySpace
{
    public class MyClass {}

    public class Foo
    {
        public void Bar()
        {
            var baz = new MyClass();
        }
    }
}

public class Qux
{
    public void Box()
    {
        var nux = new MySpace.MyClass();
    }
}

namespace OtherSpace
{
    using MySpace;

    public class Tix
    {
        public void Jeg()
        {
            var lor = new MyClass();
        }
    }
}
```

You can alias a namespace with the syntax `using MyAlias = MySpace;` and then use the alias anywhere that the namespace could be used.

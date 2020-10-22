It is unlikely that you will come across much production code that does not make use of namespaces.

An example of the syntax is:

```csharp
namespace MyNameSpace
{
    public class MyClass {}

    public class OtherClass {}
}
```

Namespaces are a way to group related code and to avoid name clashes.

According to the [official documentation][namespaces] namespaces have two principal roles:

- First, .NET uses namespaces to organize its many classes
- Second, declaring your own namespaces can help you control the scope of class and method names in larger programming projects.

Namespaces are used widely by the base class library (BCL) to organize its functionality.

#### References to namespaced types

Types enclosed in namespaces are referred to outside the namespace by prefixing the type name with the dot syntax. Alternatively, and more usually, you can place a `using` directive at the top of the file (or within a namespace) and any types in the imported namespace can be used without the prefix. Within the same namespace there is no need to qualify type names.

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

This [article][using] clearly explains the ways in which the `using` directive can be used:

- `using`: avoid having to qualify types with namespace
- `using static`: avoid having to qualify members with types (a good example is `Math.Max()`).
- `using MyAlias = YourNamespace;`: substitute a more readable name for the namespace name.

#### Clash of namespaces

.NET addresses the issue of two namespaces with the same name in different assemblies where there would be a clash of fully qualified identifier names (perhaps a scenario where multiple versions of an assembly are loaded). This issue is addressed with the [namespace alias qualifier][namespace-alias-qualifier] and the [extern alias][extern-alias].

One reason to raise this fairly niche topic is because of its use of the [`::` operator][dot-dot-operator]. You will often see the qualifier `global::` prefixing namespaces, particularly in generated code. The intention here is to avoid a potential clash with some nested namespace or class name. By prefixing a namespace with `global::` you ensure that a top-level namespace is selected.

#### Note for Java developers

When comparing with the `import` of Java `packages` some differences and similarities should be noted:

- There is no equivalent with C# of importing specific types.
- `using static` and `import static` are equivalent.
- In Java, package names have an impact on accessibility as between jars. In C# assemblies are paramount and belonging to the same namespace does not affect access level.
- The relationship between file system paths and fully qualified class names in Java is not reflected in C#'s namespaces although it is good practice where possible to give a file the same name as the principal class it contains.

[namespaces]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/namespaces/
[accessibility-levels]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/accessibility-levels
[namespace-alias-qualifier]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/namespace-alias-qualifier
[extern-alias]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias
[using]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive
[assemblies]: https://docs.microsoft.com/en-us/dotnet/standard/assembly/
[dot-dot-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/namespace-alias-qualifier

[`interfaces`][interfaces] are the primary means of [decoupling][wiki-loose-coupling] the uses of a class from its implementation. This decoupling provides flexibility for maintenance of the implementation and helps support type safe generic behavior.

The syntax of an interface is similar to that of a class or struct except that methods and properties appear as the signature only and no body is provided.

```csharp
public interface ILanguage
{
    string Speak();
}

public interface IItalianLanguage : ILanguage
{
    string Speak();
    string SpeakItalian();
}

public interface IScriptConverter
{
    string Version { get; set; }
    string ConvertCyrillicToLatin(string cyrillic);
}
```

The implementing class or struct must implement all operations defined by the interface.

Interfaces typically do one or more of the following:

- allow a number of different classes to be treated generically by the using code. In this case interfaces are playing the same role as a base class
- expose a subset of functionality for some specific purpose (such as [`IComparable<T>`][icomparable]) or
- expose the public API of a class so that multiple implementations can co-exist. One example is that of a [test double][wiki-test-double]

```csharp
public class ItalianTraveller : IItalianLanguage
{
    public string Speak()
    {
        return "Ciao mondo";
    }

    public string SpeakItalian()
    {
        return Speak();
    }
}

public class ItalianTravellerV2 : IItalianLanguage
{
    public string Speak()
    {
        return "migliorata - Ciao mondo";
    }

    public string SpeakItalian()
    {
        return Speak();
    }
}

public class FrenchTraveller : ILanguage
{
    public string Speak()
    {
        return "Ça va?";
    }
}

public class RussianTraveller : ILanguage, IScriptConverter
{
    public string Version { get; set; } = "1.0";

    public string Speak()
    {
        return "Привет мир";
    }

    public string ConvertCyrillicToLatin(string cyrillic)
    {
        throw new NotImplementedException();
    }
}

public class DocumentTranslator : IScriptConverter
{
    public string Version { get; set; } = "1.0";

    public string Translate(string russian)
    {
        throw new NotImplementedException();
    }

    public string ConvertCyrillicToLatin(string cyrillic)
    {
        throw new NotImplementedException();
    }
}
```

Code which uses the above interfaces and classes can:

- treat all speakers in the same way irrespective of language.
- allow some subsystem handling script conversion to operate without caring about what specific types it is dealing with.
- remain unaware of the changes to the italian speaker which is convenient if the class code and user code are maintained by different teams

Interfaces are widely used to support testing as they allow for easy [mocking][so-mocking-interfaces].

See this [article][dt-interfaces] for details of what types of member can be included in an interface.

Interfaces can inherit from other interfaces.

Members of an interface are public by default.

Interfaces can contain nested types, such as `const` literals, `enums`, `delegates`, `classes` and `structs`. Here, the interfaces act as [namespaces][wiki-namespaces] in the same way that classes and structs do and the behaviour and syntax is identical.

By design, C# does not support multiple inheritance, but it facilitates a kind of multiple inheritance through interfaces.

Moreover, the concept of [polymorphism can be implemented through interfaces][interface-polymorphism] underpins the interface mechanism.

#### Explicit interface implementation

Sometimes method names and signatures can be shared in two different interfaces.
In order provide a distinct implementation of these methods, C# provides [explicit implementation of interfaces][explicit-implementation]. Note that to use a particular implementation of an interface you need to convert the expression containing referencing the object to that interface. Assignment, casting or passing as a parameter will achieve this.

```csharp
public interface IFoo
{
    void X();
}

public interface IBar
{
    void X();
}

public class Census : IFoo, IBar
{
    void IFoo.X()
    {
        Console.Write("This is from Foo");
    }

    void IBar.X()
    {
        Console.Write("This is from Bar");
    }
}

public class User
{
    public void Use()
    {
        IFoo foo = new Census();
        IBar bar = new Census();
        foo.X();
        // => "This is from Foo"
        bar.X();
        // => "This is from Bar"
    }
}
```

There are a number of use cases:

- A clash of domains (as illustrated above) where methods have identical signatures.
- Methods with the same name but different return types: if you implement your own collection classes you may find that an explicit interface for the legacy `IEnumerable.GetEnumerator()`, alongside `IEnumerable<T>.GetEnuerator()`, is required. You may never make use of such the interface but the compiler may insist.
- Methods where there is no clash of names between interfaces but it is desirable that the implementing class uses the name for some related purpose: `IFormattable` has a `ToString()` method which takes a _format type_ parameter as well as parameter of type `IFormatProvider`. A class like `FormattableString` from the Base Class Library (BCL) has the interface to ensure it can be used by routines that take an `IFormattable` but it is more expressive for its main version of `ToString(IFormatProvider)` to omit the _format type_ parameter as it is not used in the implementation and would confuse API users.

#### Default implementation

Version 8 of C# addresses a nagging problem with APIs. If you add methods to an interface to enhance functionality for new implementations then it is necessary to modify all the existing implementations of the interface so that they comply with the API-contract even though they have no implementation specific behavior. C# now allows for a _default method_ to be provided as part of the interface (Java developers will be familiar). Previously, when such a change occurred a _version 2_ of the interface would exist alongside the original.

This [article][dt-interfaces] is an excellent primer on interfaces and focuses on _default implementation_ and other supporting innovations such as `static`, `private` and `virtual` members.

[interface-polymorphism]: https://www.cs.utexas.edu/~mitra/csSummer2013/cs312/lectures/interfaces.html
[explicit-implementation]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/explicit-interface-implementation
[so-mocking-interfaces]: https://stackoverflow.com/a/9226437/96167
[icomparable]: https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1?view=netcore-3.1
[wiki-test-double]: https://en.wikipedia.org/wiki/Test_double
[wiki-polymorphism]: https://en.wikipedia.org/wiki/Polymorphism_(computer_science)
[wiki-namespaces]: https://en.wikipedia.org/wiki/Namespace
[dt-interfaces]: https://www.talkingdotnet.com/default-implementations-in-interfaces-in-c-sharp-8/
[wiki-loose-coupling]: https://en.wikipedia.org/wiki/Loose_coupling
[interfaces]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/

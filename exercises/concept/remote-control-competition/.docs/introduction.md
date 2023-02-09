# Introduction

## Interfaces

An interface is a type containing members defining a group of related functionality. It distances the uses of a class from the implementation allowing multiple different implementations or support for some generic behavior such as formatting, comparison or conversion.

The syntax of an interface is similar to that of a class or struct except that methods and properties appear as the signature only and no body is provided.

```csharp
public interface ILanguage
{
    string LanguageName { get; set; }
    string Speak();
}

public class ItalianTaveller : ILanguage, ICloneable
{
    public string LanguageName { get; set; } =  "Italiano";

    public string Speak()
    {
        return "Ciao mondo";
    }

    public object Clone()
    {
        ItalianTaveller it = new ItalianTaveller();
        it.LanguageName = this.LanguageName;
        return it;
    }
}
```

All operations defined by the interface must be implemented.

Interfaces can contain instance methods and properties amongst other members

## Ordering

To allow an object to be compared to another object, it must implement the `IComparable<T>` interface.
This interface has a single method that needs to be implemented: `int CompareTo(T other)`.

There are three possible return values for the `CompareTo` method:

- Value smaller than zero: the current object is smaller than the other object.
- Value greater than zero: the current object is greater than the other object.
- Value is zero: the current object is equal to the other object.

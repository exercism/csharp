The principal arithmetic and comparison operators can be adapted for use by your own classes and structs. This is known as _operator overloading_.

This [article][operator-overloading] is a thorough discussion of the syntax as well as which operators can be overloaded and those that can't.

Most operators have the form:

```csharp
static <return type> operaator <operator symbols>(<parameters>);
```

[Cast operators][ud-conversion-operators] have the form:

```csharp
static (explicit|implicit) operator <cast-to-type>(<cast-from-type> <parameter name>);
```

Operators behave in the same way as static methods.

- An operator symbol takes the place of a method identifier, and they have parameters and a return type. The type rules for parameters and return type follow your intuition and you can rely on the compiler to provide detailed guidance.
- For binary operations the first parameter takes the left-hand argument to the operation.
- Operators have a signature comprising two parameters (in the case of binary operations) and a return type or a single parameter and return type in the case of unary operators.
- For binary operators, one of the parameter types must be that of the declaring class.
- In the case of type conversions either the parameter or the return type must be the type of the declaring class.
- For incrementing and decrementing operators the parameter and return type must be that of the declaring class.

Syntax examples:

```csharp
struct Point
{
    decimal x;
    decimal y;

    public static bool operator ==(Point pt, Point ptOther)
    {
        return pt.x == ptOther.x && pt.y == ptOther.y;
    }

    public static bool operator !=(Point pt, Point ptOther)
    {
        return !(pt == ptOther);
    }

    public static Point operator *(Point pt, decimal scale)
    {
        var ptNew = new Point();
        ptNew.x = pt.x * scale;
        ptNew.y = pt.y * scale;
        return ptNew;
    }

    public static implicit operator Point((decimal x, decimal y) xy)
    {
        var pt = new Point();
        pt.x = xy.x;
        pt.y = xy.y;
        return pt;
    }

    public static explicit operator (decimal x, decimal y)(Point pt)
    {
        return (pt.x, pt.y);
    }
}
```

It is often productive to implement an [`Equals()`][equals] method and call it from the `==` operator. Similarly, for comparisons you can implement the [`IComparable`][icomparable] interface. In both cases you get to kill two birds with just over one stone.

You should note that you cannot create operators from symbols that are not part of the standard set of operators. You can use only existing symbols for those operations where the documentation specifies that they can be overloaded. The operators that can be overloaded are listed [here][overloadable-operators].

Note that the order of parameters is important where they differ in type. In the above example code `pt * 10m` is a legal expression whereas `10m * pt` will not compile.

#### Reference

This documentation of [operator overloading][operator-overloading] details the syntax.

[operator-overloading]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-overloading
[ud-conversion-operators]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators
[overloadable-operators]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-overloading#overloadable-operators
[equals]: https://docs.microsoft.com/en-us/dotnet/api/system.object.equals?view=netcore-3.1#System_Object_Equals_System_Object_
[icomparable]: https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1?view=netcore-3.1

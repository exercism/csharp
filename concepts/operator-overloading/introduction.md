The principal arithmetic and comparison operators can be adapted for use by your own classes and structs. This is known as _operator overloading_.

Most operators have the form:

```csharp
static <return type> operator <operator symbols>(<parameters>);
```

Cast operators have the form:

```csharp
static (explicit|implicit) operator <cast-to-type>(<cast-from-type> <parameter name>);
```

Operators behave in the same way as static methods. An operator symbol takes the place of a method identifier, and they have parameters and a return type. The type rules for parameters and return type follow your intuition and you can rely on the compiler to provide detailed guidance.

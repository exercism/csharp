## General

- [Properties][docs.microsoft.com-properties]
- [Using Properties][docs.microsoft.com-using-properties]

## 1. Allow the weight to be set on the weighing machine

A property with a private [backing field][docs.microsoft.com-properties-with-backing-fields] is appropriate here.

## 2. Ensure that a negative input weight is rejected.

Add [validation][stackoverflow.com-validating-properties] to the `InputWeight`'s `set` accessor to throw an exception.

## 3. Allow the US weight to be retrieved

A property can return a reference to an object.

## 4. Allow the machine's units to be set to pounds

`Units` is a good candidate for an [auto-implemented property][docs.microsoft.com-auto-implemented-properties].

## 5. Allow a tare adjustment to be applied to the weighing machine

Accessors can have [different access levels][docs.microsoft.com-properties-and-restricted-access] to each other.

[docs.microsoft.com-properties]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties
[docs.microsoft.com-using-properties]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties
[docs.microsoft.com-properties-with-backing-fields]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties#properties-with-backing-fields
[stackoverflow.com-validating-properties]: https://stackoverflow.com/questions/4946227/validating-properties-in-c-sharp
[docs.microsoft.com-auto-implemented-properties]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
[docs.microsoft.com-properties-and-restricted-access]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/restricting-accessor-accessibility

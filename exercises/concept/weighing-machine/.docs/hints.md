# Hints

## General

- [Properties][docs.microsoft.com-properties]
- [Using Properties][docs.microsoft.com-using-properties]

## 1. Allow the weighing machine to have a precision

- A get only property that can be intialised only from the constructor.

## 2. Allow the weight to be set on the weighing machine

- You should add a property with a private [backing field][docs.microsoft.com-properties-with-backing-fields].

## 3. Ensure that a negative input weight is rejected

- The `value` keyword is used to refer to the value the caller wants the property to have.
- Add [validation][stackoverflow.com-validating-properties] to the `Weight`'s `set` accessor to throw an exception when the value is invalid.

## 4. Allow a tare adjustment to be applied to the weighing machine

- You should add an [auto-implemented property][docs.microsoft.com-auto-implemented-properties] for the tare adjustment.

## 5. Ensure that the weighing machine has a default tare adjustment

- You can initialize an [auto-implemented property][docs.microsoft.com-auto-implemented-properties] like you can initialize a field.

## 6. Allow the weight to be retrieved

- You should add a `get`-only property in which the correct display weight is calculated.

[docs.microsoft.com-properties]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties
[docs.microsoft.com-using-properties]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties
[docs.microsoft.com-properties-with-backing-fields]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties#properties-with-backing-fields
[stackoverflow.com-validating-properties]: https://stackoverflow.com/questions/4946227/validating-properties-in-c-sharp
[docs.microsoft.com-auto-implemented-properties]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
[docs.microsoft.com-properties-and-restricted-access]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/restricting-accessor-accessibility

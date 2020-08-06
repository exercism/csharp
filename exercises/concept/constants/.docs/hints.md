## General

- [Readonly fields][readonly-fields]: how to define a readonly field.
- [Constants][constants]: how to define constants.

## 1. Set appropriate fields and properties to const

- Constants in C# are discussed [here][constants].

## 2. Set appropriate fields to readonly

- Read-only fields are discussed [here][readonly-fields].

## 3. Remove set accessor or make it private for any appropriate field

- This [article][properties] discusses C# properties.

## 4. Ensure that the admin cannot be tampered with

- See [this][defensive-copying] discussion on the pattern and purpose of defensive copying.

## 5. Ensure that the developers cannot be tampered with

- Read-only dictionaries are discussed [here][readonly-dictionaries].

[readonly-fields]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly#readonly-field-example
[constants]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constants
[properties]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties
[defensive-copying]: https://www.informit.com/articles/article.aspx?p=31551&seqNum=2
[readonly-dictionaries]: https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.readonlydictionary-2?view=netcore-3.1

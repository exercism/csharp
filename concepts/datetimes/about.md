A `DateTime` in C# is an immutable object that contains both date _and_ time information. The date and time information can be accessed through its built-in [properties][properties].

Manipulating a `DateTime` can be done by calling one of its [methods][methods]. As `DateTime` values can never change after having been defined, all methods that appear to modify a `DateTime` will actually return a new `DateTime`.

Comparing `DateTime` instances can be done using the default comparison operators (`<`, `>`, etc.). The current date (and time) can be retrieved through the `DateTime.Now` property.

An important aspect of dates in C# is that they are culture-dependent. As such, any `DateTime` method that deals with `string`s will be dependent on the current culture. This includes the [`DateTime.Parse()` method][parse] that parses a `string` to a `DateTime`, as well as the `DateTime` class' [`ToString()` method][to-string] that converts a `DateTime` to a `string`.

[parse]: https://docs.microsoft.com/en-us/dotnet/api/system.datetime.parse?view=netcore-3.1#System_DateTime_Parse_System_String_
[operators]: https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netcore-3.1#operators
[properties]: https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netcore-3.1#properties
[to-string]: https://docs.microsoft.com/en-us/dotnet/api/system.datetime.tostring?view=netcore-3.1
[methods]: https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netcore-3.1#methods

In C# dates are represented as `DateTime` instances, which contains both date _and_ time information. Dates can be compared using the default comparison operators (`<`, `>`, etc.). The current date (and time) can be retrieved through the static `DateTime.Now` property.

An important aspect of dates in C# is that they are culture-dependent. As such, any `DateTime` method that deals with `string`s (either as input or output) will be dependent on the current culture.

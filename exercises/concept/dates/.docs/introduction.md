The C# `DateTime` type is a type that contains both date and time information.

The textual representation of dates and times is dependent on the _culture_. Consider a `DateTime` with its date set to March 28 2019 and its time set to 14:30:59. Converting this `DateTime` to a `string` when using the `en-US` culture (American English) returns `"3/28/19 2:30:59 PM"`. When using the `fr-BE` culture (Belgian French), the same code returns a different value: `"28/03/19 14:30:59"`.

Understanding which `DateTime` methods are culture-dependent is important to know. In general, any `DateTime` method that deals with `string`s (either as input or output) will be dependent on the current culture.

# About

You can use [Enumeration types][enumeration types] whenever you have a fixed set of constant values. Using an `enum` gives one a type-safe way of interacting with constant values. Defining an enum is done through the `enum` keyword. An enum member is referred to by prepending it with the enum name and a dot (e.g. `Status.Active`).

Each enum member is an association of a name and an `int` value. If the first member does not have an explicit value, its value is set to `0`. If no value is explicitly defined for an enum member, its value is automatically assigned to the previous member's value plus `1`.

```csharp
enum Season
{
    Spring,     // Auto set 0
    Summer = 2, // Set the value 2
    Autumn,     // Auto set 3
    Winter = 7  // Set the value 7
}
```

Enums are very declarative. Compare the following two method calls:

```csharp
Users.WithStatus(1)
Users.WithStatus(Status.Active)
```

For someone reading the code, the second version (with enum) will be easier to comprehend.

## Numeric type Enums

While the default numeric type of the values is `int`, it can be changed by explicitly specifying any other [integral numeric][integral numeric] type.

The following enum use the `byte` numeric type for its values:

```csharp
enum Priority : byte
{
    Low = 0,
    Medium = 127,
    High = 255
}
```

## Convert to an Enum member

You should always consider using an enum whenever you want to model something like a boolean. Besides the aforementioned readability benefits, enums have another advantage over booleans: new values can always be added to an enum, whereas a boolean value will only ever be `true` or `false`. Using an enum is thus more future proof.

```csharp
enum Status
{
    Inactive = 0,
    Active = 1
}

Status active = (Status) 1;
active == Status.Active; // True
```

Note that while one _can_ cast integer values to an enum, doing so can lead to unexpected results when the integer value doesn't map to some enum value:

```csharp
Status status = (Status) 2;
status == Status.Inactive; // False
status == Status.Active;   // False
```

## Parsing an enum

It's sometimes useful to convert a string to an enum member based on its name with [`Enum.Parse`][enum parse]:

```csharp
var input = "Inactive";
Status status = (Status)Enum.Parse(typeof(Status), input);
// Inactive
```

To check if a name or a value exists in the enum, you can use [`Enum.TryParse`][enum tryparse] or [`Enum.IsDefined`][enum isdefined], both return a boolean indicating if the enum member exists:

```csharp
bool doesExist = Enum.IsDefined(typeof(Status), "Inexistent");
// False
```

More examples and best practices are available [here][enum examples].

[enumeration types]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum
[integral numeric]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
[enum parse]: https://docs.microsoft.com/en-us/dotnet/api/system.enum.parse?view=net-6.0
[enum tryparse]: https://docs.microsoft.com/en-us/dotnet/api/system.enum.tryparse?view=net-6.0
[enum isdefined]: https://docs.microsoft.com/en-us/dotnet/api/system.enum.isdefined?view=net-6.0
[enum examples]: https://docs.microsoft.com/en-us/dotnet/api/system.enum?view=net-6.0#examples

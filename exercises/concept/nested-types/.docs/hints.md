## General

- This documentation of [nested types][nested-types] details the syntax.

## 1. Separate concerns between the car itself and the telemetry system

- Members of `RemoteControlCar` suffixed with "\_Telemetry" could be moved to a separate class.

## 2. Prevent other code taking too many dependencies on the Telemetry type

- [Interfaces][interfaces] are the secret sauce here.

## 3. Prevent other code from taking dependencies on the Speed struct

- Give some consideration to [access levels][access-levels].

[nested-types]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/nested-types
[interfaces]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/
[access-levels]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers

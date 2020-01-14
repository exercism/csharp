# Hints

### General

- [docs.microsoft.com numbers tutorial][tutorial-docs.microsoft-numbers]

### 1. Calculate the production rate per second

- Determining the success rate can be done through a [conditional statement][tutorial-csharp.net-if-statement].
- C# allows for multiplication to be applied to two different number types (such as an `int` and a `double`). It will automatically return the "largest" data type.

[tutorial-docs.microsoft-numbers]: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/intro-to-csharp/numbers-in-csharp-local
[tutorial-csharp.net-if-statement]: https://csharp.net-tutorials.com/control-structures/if-statement/

### 2. Calculate the number of working items produced per second

- Whereas an `int` can be automatically converted to a `double`, the reverse does not hold. The reason for this is that the range of numbers an `int` can represent is smaller than a `double`. To force this conversion, one can either use one of the [`Convert` class' methods][docs-microsoft.com-convert] or [cast to an int][tutorial-dotnetperls.com-cast-int].

[docs-microsoft.com-convert]: https://docs.microsoft.com/en-us/dotnet/api/system.convert?view=netcore-3.0#examples
[tutorial-dotnetperls.com-cast-int]: https://www.dotnetperls.com/cast-int

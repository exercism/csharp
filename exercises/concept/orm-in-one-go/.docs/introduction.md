You saw in (TODO cross-ref-tba) that the `IDispose` interface could be used to signal that some object's resource or other program state needed to be released or reset when the object was no longer required (and that relying on the garbage collector would not achieve this or provide the required level of control) and that `IDisposable.Dispose()` method was the natural place for such cleanup operations.

There is another construct, the `using` block, that enables, from the caller's perspective, all the resource lifetime management to be gathered into a single statement.

```csharp
using (var file = new File("my_secrets"))
{
    file.WriteSecret("xxxxxxx");
}
```

In the above example the file system resources associated with `file` will be released back to the operating system when the `using` block is exited.

For the pattern to work the variable in the using statement must be a reference type that implements the `IDisposable` interface and must release resources/reset program state in its `Dispose()` method.

C# 8 introduces a refinement to the pattern. A using statement can placed at the beginning of a block.

```csharp
using var drawingResource = some_provided_or_new_object;
try
{
    drawingResource.DrawSomething();
}
catch (Exception)
{
    throw;
}
```

Java developers may recognize this as an analog of the _automatic resource management_ mechanism introduced in Java 7.

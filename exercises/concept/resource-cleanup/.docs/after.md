The [`IDisposable`][idisposable] interface is central to resource cleanup and has two significant roles in C#:

- It indicates to users of the implementing class that they are responsible for letting the class know (by calling the [`Dispose()`][dispose] method) that it is no longer required so that it can release any unmanaged resources or reset its internal state as appropriate. This contrasts with the normal approach to cleaning up of allowing the [garbage collector][garbage-collector] to clean everything up (principally, release memory).
- In conjunction with the compiler and runtime the `IDisposable` interface supports the [`using` statement][using-statement] discussed in the `resource-lifetime` exercise.

It is possible but unlikely that `Dispose()` will be called through the interface in some sort of generic cleanup routine.

`IDisposable` is most commonly encountered with library classes that wrap operating system (unmanaged) resources such as [`System.IO.Stream`][stream] and [`System.IO.TextReader`][text-reader]. (`Stream`s and `TextReader`s are covered in other exercises).

```csharp
public class TextHandler : IDispoable
{
    private TextReader reader = new TextReader(...);

    public void Dispose()
    {
        reader.Dispose();
    }
}
```

If a class you are using implements the `IDispoable` interface then you must ensure that `Dispose()` is called (by use of [`catch` and `finally`][try-catch-finally] clauses) when the instance is no longer required. If a class has a member which implements `IDisposable` then it may well need to implement `IDisposable` itself so that `Dispose()` can be called to dispose of the `IDisposble`-implementing member.

```csharp
public class Activity : IDisposable
{
    private MyResource myResource;

    public Activity()
    {
        myResource = new MyResource();
    }

    public void Perform()
    {
        try
        {
            myResource.BeUseful();
        }
        catch (Exception)
        {
            myResource.Dispose();
        }
    }

    public void Dispose()
    {
        myResource.Dispose();
    }
}
```

The `IDisposable` interface may be useful even where no unmanaged resources are in the mix. Say you have a long-lived object which requires short-lived objects to register themselves with it and then unregister when they are no longer required. Implementing `IDisposable` on the short-lived object puts a developer using that class on notice that `Dispose()` needs to be called at the end of the short-lived object's life.

#### Dispose pattern

You will see references in the documentation to the [dispose pattern][dispose-pattern]. The _dispose pattern_ includes calling `Dispose()` from a class's [finalizer][finalizer] and ensuring that disposal of resources in base classes is handled correctly. The _dispose pattern_ is dealt with in a later exercise.

The _dispose pattern_ mostly relates to unmanaged resources. If you are using [P/Inovke mechanism][native-interoperability] and `extern` methods then you need to understand how and when to implement the dispose pattern. Most C# developers rarely have to deal directly with unmanaged resources in this way.

[finalizer]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/destructors
[using-statement]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement
[idisposable]: https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=netcore-3.1
[dispose]: https://docs.microsoft.com/en-us/dotnet/api/system.idisposable.dispose?view=netcore-3.1
[stream]: https://docs.microsoft.com/en-us/dotnet/api/system.io.stream?view=netcore-3.1
[text-reader]: https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netcore-3.1
[native-interoperability]: https://docs.microsoft.com/en-us/dotnet/standard/native-interop/
[dispose-pattern]: https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
[garbage-collector]: https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals
[try-catch-finally]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch-finally

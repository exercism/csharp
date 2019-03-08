To be more specific, you are not allowed to use any of the built-in [LINQ methods](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable?view=netcore-2.1#methods).

### Laziness test

Since `accumulate` returns an `IEnumerable`, it's execution is deferred until `ToList()` it is called on it, which is tested with the `Accumulate_is_lazy` method

## Hints		
This exercise requires you to write an extension method. For more information, see [this page](https://msdn.microsoft.com/en-us//library/bb383977.aspx).
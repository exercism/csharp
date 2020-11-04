## General

Documentation related to `IDisposable` is [here][idisposable]

## 2. Write some data to the database

[`try`/`catch`][try-catch-finally] is necessary to ensure that the database is restored to its `Closed` state if an exception is thrown because of bad data.

## 3. Commit previously written data to the database

[`try`/`catch`][try-catch-finally] is necessary to ensure that the database is restored to its `Closed` state if an exception is thrown because of bad data.

[idisposable]: https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=netcore-3.1
[try-catch-finally]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch-finally

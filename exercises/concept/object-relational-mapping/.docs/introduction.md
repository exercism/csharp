# Introduction

If a class implements the `IDisposable` interface then its `Dispose()` method must be called whenever an instance is no longer required. This is typically done from a `catch` or `finally` clause or from the `Dispose()` routine of some caller. `Dispose()` provides an opportunity for unmanaged resources such as operating system objects (which are not managed by the .NET runtime) to be released and the internal state of managed resources to be reset.

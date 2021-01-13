# Memory allocation

The important thing about allocating memory in C# is that it is done _automatically_; there is no need to manually allocate memory. To allow the automatic memory to also be deallocated when it is no longer used, C# uses a [garbage collector][docs.microsoft.com_garbage-collection-fundamentals].

There are two different types of memory used when working with C#:

- The stack.
- The heap.

The stack is short-lived and has limited space available. Exceeding the maximum amount of allowed memory of the stack results in a `StackOverflowException` being thrown. Each thread has its own stack. As the stack is automatically "unwinded" after a method returns, there is no need for the garbage collector to be involved. This means that (de)allocating memory on the stack is very fast.

The heap is long-lived and has lots of memory available. When an object is allocated, the memory allocator will find some free memory on the heap and allocate it. The heap is shared between threads and can be used to share data. Once every while, the garbage collector will halt execution (a "GC pause") and check if there are objects that are no longer being used. If so, the memory for these objects will be deallocated and their memory will become available for later allocation again.

## What goes where?

In principle, value types are allocated on the stack and reference types on the heap. There are some exceptions to this, for example when a value type is part of a reference type (e.g. a class with an `int` field).

## Resources

- [Garbage collection fundamentals][docs.microsoft.com_garbage-collection-fundamentals]
- [Jetbrains memory management concepts][jetbrains.com_memory-management-concepts]
- [Jon skeet on C# memory allocation][jonskeet.uk_memory]
- [Pro .NET memory management (book)][pro-dotnet-memory]

[docs.microsoft.com_garbage-collection-fundamentals]: https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals
[jonskeet.uk_memory]: https://jonskeet.uk/csharp/memory.html
[jetbrains.com_memory-management-concepts]: https://www.jetbrains.com/help/dotmemory/NET_Memory_Management_Concepts.html
[pro-dotnet-memory]: https://prodotnetmemory.com/

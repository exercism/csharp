# Introduction

Memory in C# is (usually) allocated _automatically_; there is no need to manually allocate memory. To allow the automatic memory to also be deallocated when it is no longer used, C# uses a garbage collector.

There are two different types of memory used when working with C#:

- The stack: short-lived and with limited space available.
- The heap: long-lived and lots of memory available.

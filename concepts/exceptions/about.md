It is important to note that `exceptions` should be used in cases where something exceptional happens, an error that needs special handeling. It should not be used for control-flow of a program, as that is considered bad design, which often leads to bad performance and maintainability.

Some of the more common exceptions include `IndexOutOfRangeException`, `ArgumentOutOfRangeException`, `NullReferenceException`, `StackOverflowException`, `ArgumentException`, `InvalidOperationException` and `DivideByZeroException`.

Some of the cases when exceptions should be thrown include:

- if the method cannot complete its defined functionality
- an inappropriate call to an object is made, based on the object state
- when an argument to a method causes an exception

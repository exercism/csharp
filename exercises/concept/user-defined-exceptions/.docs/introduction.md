A user-defined exception is any class defined in your code that is derived from `System.Exception`. It is subject to all the rules of class inheritance but in addition the compiler and language runtime treat such classes in a special way allowing their instances to be thrown and caught outside the normal control flow as discussed in the `exceptions` exercise.

User-defined exceptions are often used to carry extra information such as a message and other relevant data to be made available to the catching routines.

## Exception Filters

`when` is the key word in filtering exceptions. It is placed after the catch
statement and can take a boolean expression containing any values in scope at the time. If the expression evaluates to true then the block associated with that `catch` statement is executed otherwise the next `catch` statement, if any, is checked.

```csharp
try
{
    // do stuff
}
catch (Exception ex) when (ex.Message != "")
{
    // output the message when it is not empty
}
catch (Exception ex)
{
    // show stack trace or something.
}
```

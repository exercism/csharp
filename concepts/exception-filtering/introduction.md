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

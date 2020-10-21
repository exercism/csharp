TODO: This may need a more rounded introduction to filtering here.
`when` is the keyword in filtering exceptions. It is placed after the catch
statement and can take a boolean expression containing any values in scope at the time. They don't just have to be members of the exception itself. If the type of the exception matches and the expression evaluates to true then the block associated with that `catch` statement is executed otherwise the next `catch` statement, if any, is checked.

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

- This [Exception filters][exception-filters] article shows how to filter exceptions.

[exception-filters]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/when

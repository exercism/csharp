Many [types of struct and class members][expression-bodied-members] (fields being the primary exception) can use the expression-bodied member syntax. Defining a member with an expression often produces more concise and readable code than traditional blocks/statements.

```csharp
public int Times3(int input) => input * 3;

public int Interesting => 1729;
```

Expression-bodied-members cannot have blocks of multiple statements, but those with a functional background should be warned that anything that a traditional member can do can be achieved by one of these members. The "expression" can be an assignment operation creating side effects, or a method invocation meaning that anything is possible.

[expression-bodied-members]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members

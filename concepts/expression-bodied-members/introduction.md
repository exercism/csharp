Many types of struct and class members (fields being the primary exception) can use the expression-bodied member syntax. Defining a member with an expression often produces more concise and readable code than traditional blocks/statements.

Methods and read-only properties are amongst the members that can be defined with expression bodies.

```csharp
public int Times3(int input) => input * 3;

public int Interesting => 1729;
```

In C#, a tuple is a data structure which organizes data, holding two or more fields
of any type.

A tuple is typically created by placing 2 or more expressions separated by comas,
within a set of parentheses.

```csharp
string boast = "All you need to know";
bool success = !string.IsNullOrWhiteSpace(boast);
(bool, int, string) triple = (success, 42, boast);
```

A tuple can be used in assignment and initialization operations, as a return value or a method argument.

Fields are extracted using dot syntax. By default, the first field is `Item1`,
the second `Item2`, etc. Non-default names are discussed below.

```csharp
// initialization
(int, int, int) vertices = (90, 45, 45);

// assignment
vertices = (60, 60, 60);

//  return value
(bool, int) GetSameOrBigger(int num1, int num2)
{
    return (num1 == num2, num1 > num2 ? num1 : num2);
}

// method argument
int Add((int, int) operands)
{
    return operands.Item1 + operands.Item2;
}
```

Field names `Item1` etc. do not make for readable code. The code below shows
2 ways to name the fields of tuples. Note also, in the code below, that `var` can be used with tuples and the type inferred. This works equally well for tuples with named and unnamed fields.

```csharp
// name items in declaration
(bool success, string message) results = (true, "well done!");
bool mySuccess = results.success;
string myMessage = results.message;

// name items in creating expression
var results2 = (success: true, message: "well done!");
bool mySuccess2 = results2.success;
string myMessage2 = results2.message;
```

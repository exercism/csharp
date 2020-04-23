In C#, the `null` literal is used to denote the absence of a value. A
_nullable_ type is a type that allows `null` values. By default
reference types are nullable and value types are non nullable. The
`?` suffix to a variable's type makes it nullable if it is not. From
C# 8.0 on, one can [make reference types non nullable by
default][nullable-csharp-8], just like value types.

```csharp
int? nullable = 5;
nullable = null;

int nonNullable = 5;

// Would result in compile error as type is not nullable
// nonNullable = null;
```

A common mistake is to access a member (e.g. a method or property) on a nullable
variable whose value is `null`. This will cause the C# runtime
to raise a `NullReferenceException`.

The C# compiler can help us avoiding such errors. If we try to
compile the following code:

```csharp
string? userName = ...;

...

Console.WriteLine(userName.Length);
```

The compiler will give the following warning message:

```
Dereference of a possibly null reference. (CS8602)
```

A good practice is testing if a nullable value is not `null` before
trying to do something with it. There are some cases however, where we
know for sure that, given the context, a variable cannot be `null`.

In order to dismiss the warning, we can use the operator `!`:

```csharp
Console.WriteLine(userName!.Length);
```

Finally, sometimes, we want to provide a default value to a variable,
in case it is `null`. We know how to use an `if` block to check
that. However, the more nullable variables we need to check, the more
cumbersome it gets.

The `??` and `?.` operators are a simple shortcuts for that:

```csharp
// prints: "default" if `userName` is `null`
Console.WriteLine(userName ?? "default");

// This code is equivalent to:
string userNameValue;
if (userName == null)
{
    userNameValue = "default";
}
else
{
    userNameValue = userName;
}
Console.WriteLine(userNameValue);



// prints: `null` if `userName` is `null`
Console.WriteLine(userName?.Length);

// This code is equivalent to
int userNameLength;
if (userName == null)
{
    userNameLength = 0;
}
else
{
    userNameLength = userName.Length;
}
Console.WriteLine(userNameLength);
```

With `A ?? B`, the C# runtime replaces the expression `A` with `B` if
`A` evaluates to `null`. The operator `?.` behaves similarly, the C#
runtime evaluates the expression `A?.B` by `null` if `A` is null,
without throwing a `NullReferenceException`. It executes `A.B`
otherwise.

[nullable-csharp-8]: https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references

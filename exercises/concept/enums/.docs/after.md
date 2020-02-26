Whenever you have a fixed set of constant values, an `enum` can be used. Using an enum gives one a type-safe way of interacting with constant values.

Another benefit of enums are that they are very declarative. Compare the following two pieces of code:

```csharp
Users.WithStatus(1)
```

vs

```csharp
Users.WithStatus(Status.Active)
```

For someone reading the code, the second (enum) version will be easier to comprehend.

You should always consider using an enum whenever you want to model something as a boolean. Besides the aforementioned readability benefits, enums have another advantage over booleans: new values can always be added to an enum, whereas a boolean value will only ever be `true` or `false`. Using an enum is thus more future proof.

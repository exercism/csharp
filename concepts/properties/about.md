The two main types of property are

1. auto-implemented properties where the `get` and `set` accessors have no body.
   They may or may not be explicitly initialized. For example:
   ```csharp
   public int MyProperty {get; set;} = 42;
   ```
2. those where the accessors evaluate expressions and execute statements. The code can
   be as simple as returning or assigning a backing field. For example:
   ```csharp
   private int myField;
   public int MyProperty
   {
     get { return myField; }
     set { myField = value; }
   }
   ```

There is considerable overlap of behavior and power between properties and methods.
When they are not auto-implemented properties can contain any statement or expression
that can appear within the scope of the class. In a common case they are often described
as wrapping a backing field.
Although much of the time it is obvious whether to code behavior as a property or method in a particular case it is
often a judgement call for the coder and in particular how much code should be
executed within the accessors. Validation in a set accessor and simple calculation or formatting in a
get accessor are commonly found:

```csharp
private float fraction;
public float Percentage
{
  get { return fraction * 100; }
  set
  {
    if (value < 0 || value > 100)
    {
      throw new ArgumentException("Percentage must be between 0 and 100");
    }
    fraction = value / 100;
  }
}
```

In a similar way to other class members properties can have access levels.
Most often properties will have a non-private access level in line with
their essential purpose. Sometimes one of the accessors will have
a different access level to the property. In the case of `TareWeight`
under the rather artificial "security" constraint there was an opportunity
to have a public property with a private getter. This means that code external
to the class can set the value of the property but it can only be read (get) by code within
the class.

```csharp
public int ConfidentialValueUsedInternally {private get; set; }
```

Non-public set accessors are also supported but a more common case is where
the set accessor may be omitted completely. This is maybe because
the value of the property is set in the class's constructor.

```csharp
class MyClass
{
  public MyClass( int importantValue)
  {
    ConstructedValue = importantValue;
  }
  public int ConstructedValue {get;}
}
```

This exercise has dealt with basic use of properties. You will find more advanced
topics in other exercises:

- expression bodied properties, get accessors and set accessors (covered by expression-bodied members)
- properties on interfaces (covered by Interfaces)
- properties/abstract properties on abstract classes (covered by Inheritance)
- use of the `readonly` keyword with properties (covered by Immutability)
- static properties (covered by Statics)
- indexers (covered by Indexers)

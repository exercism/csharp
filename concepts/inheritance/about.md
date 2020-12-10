In C#, a _class_ hierarchy can be defined using _inheritance_, which allows a derived class (`Car`) to inherit the behavior and data of its parent class (`Vehicle`). If no parent is specified, the class inherits from the `object` class.

Parent classes can provide functionality to derived classes in three ways:

- Define a regular method.
- Define a [`virtual` method][virtual-keyword], which is like a regular method but one that derived classes _can_ change.
- Define an [`abstract` method][abstract-keyword], which is a method without an implementation that derived classes _must_ implement. A class with `abstract` methods must be marked as [`abstract`][abstract-classes] too. Abstract classes cannot be instantiated.

The [`protected` access modifier][protected-keyword] allows a parent class member to be accessed in a derived class, but blocks access from other classes. Derived classes thus can access `public` and `protected` parent class members, but not `private` parent class members.

Derived classes can access parent class members through the [`base` keyword][base-keyword].

```csharp
// Inherits from the 'object' class
abstract class Vehicle
{
    // Can be overridden
    public virtual void Drive()
    {
    }

    // Must be overridden
    protected abstract int Speed();
}

// Cannot be inherited from
sealed class Car : Vehicle
{
    public override void Drive()
    {
        // Override virtual method

        // Call parent implementation
        base.Drive();
    }

    protected override int Speed()
    {
        // Implement abstract method
    }
}
```

The constructor of a derived class will [automatically call its parent's constructor][constructors] _before_ executing its own constructor's logic. Arguments can be passed to a parent class' constructor using the [`base` keyword][base-keyword-constructor]. As abstract classes cannot be instantiated, their constructors can be made `protected`.

```csharp
abstract class Vehicle
{
    protected Vehicle(int wheels)
    {
        Console.WriteLine("Called first");
    }
}

class Car : Vehicle
{
    public Car() : base(4)
    {
        Console.WriteLine("Called second");
    }
}
```

Where more than one class is derived from a base class the two (or more) sub-classes will often implement different versions of a base class method. This is a very important principle called [polymorphism][polymorphism]. For instance in a variation on the above example we show how code using `Vehicle` can change its behavior depending on what type of vehicle has been instantiated.

```csharp
abstract class Vehicle
{
   public abstract string GetDescription();
}

class Car : Vehicle
{
   public Car()
   {
   }

   public override string GetDescription()
   {
      return "Runabout";
   }
}

class Rig : Vehicle
{
   public Rig()
   {
   }

   public override string GetDescription()
   {
      return "Big Rig";
   }
}

Vehicle v1 = new Car();
Vehicle v2 = new Rig();

v1.GetDescription();
// => Runabout
v2.GetDescription();
// => Big Rig
```

To prevent a class being inherited, add the [`sealed` modifier][sealed-classes].
Some practitioners try to avoid inheriting from concrete classes (as discussed in [this SO question][pro-sealed]) and the _sealed_ modifier supports this approach. On the other hand many C# developers consider them a hindrance to maintenance as discussed in some of the comments on [this question][anti-sealed]. The advice is to use the sealed modifier sparingly until you have gained confidence in their use for your requirements.

The following [article][new-vs-override] describes `new` as an alternative to the `override` modifier. This is occasionally useful, perhaps with convoluted class hierarchies and/or some sort of clash of libraries.

[abstract-keyword]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract
[virtual-keyword]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/virtual
[override-keyword]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/override
[base-keyword]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/base
[base-keyword-constructor]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/base#example-1
[protected-keyword]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/protected
[sealed-keyword]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/sealed
[constructors]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-constructors
[abstract-classes]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members#abstract-classes-and-class-members
[sealed-classes]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members#sealed-classes-and-class-members
[pro-sealed]: https://stackoverflow.com/questions/16724946/why-derive-from-a-concrete-class-is-a-poor-design
[anti-sealed]: https://stackoverflow.com/questions/7777611/when-and-why-would-you-seal-a-class
[new-vs-override]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords
[polymorphism]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/polymorphism

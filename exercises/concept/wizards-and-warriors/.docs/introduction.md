## inheritance

In C#, a _class_ hierarchy can be defined using _inheritance_, which allows a derived class (`Car`) to inherit the behavior and data of its parent class (`Vehicle`). If no parent is specified, the class inherits from the `object` class.

Parent classes can provide functionality to derived classes in three ways:

- Define a regular method.
- Define a `virtual` method, which is like a regular method but one that derived classes _can_ change.
- Define an `abstract` method, which is a method without an implementation that derived classes _must_ implement. A class with `abstract` methods must be marked as `abstract` too. Abstract classes cannot be instantiated.

The `protected` access modifier allows a parent class member to be accessed in a derived class, but blocks access from other classes.

Derived classes can access parent class members through the `base` keyword.

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

class Car : Vehicle
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

The constructor of a derived class will automatically call its parent's constructor _before_ executing its own constructor's logic. Arguments can be passed to a parent class' constructor using the `base` keyword:

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

Where more than one class is derived from a base class the two (or more) classes will often implement different versions of a base class method. This is a very important principle called polymorphism. For instance in a variation on the above example we show how code using `Vehicle` can change its behavior depending on what type of vehicle has been instantiated.

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

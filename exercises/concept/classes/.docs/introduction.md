The primary object-oriented construct in C# is the _class_, which is a combination of data (_fields_) and behavior (_methods_). The fields and methods of a class are known as its _members_.

Access to members can be restricted through access modifiers, the two most common ones being:

- `public`: the member can be accessed by any code (no restrictions).
- `private`: the member can only be accessed by code in the same class.

You can think of a class as a template for creating instances of that class. To create an instance of a class (also known as an _object_), the `new` keyword is used:

```csharp
class Car
{
}

// Create two car instances
var myCar = new Car();
var yourCar = new Car();
```

Fields have a type and a name (defined in camelCase) and can be defined anywhere in a class (defined in PascalCase):

```csharp
class Car
{
    // Accessible by anyone
    public int weight;

    // Only accessible by code in this class
    private string color;
}
```

One can optionally assign an initial value to a field. If a field does _not_ specify an initial value, it wll be set to its type's default value. An instance's field values can be accessed and updated using dot-notation.

```csharp
class Car
{
    // Will be set to specified value
    public int weight = 2500;

    // Will be set to default value (0)
    public int year;
}

var newCar = new Car();
newCar.weight; // => 2500
newCar.year;   // => 0

// Update value of the field
newCar.year = 2018;
```

Private fields are usually updated as a side-effect of calling a method. Such methods usually don't return any value, in which case the return type should be `void`:

```csharp
class CarImporter
{
    private int carsImported;

    public void ImportCars(int numberOfCars)
    {
        // Update private field from public method
        carsImported = carsImported + numberOfCars;
    }
}
```

Object initializers are an alternative to constructors. The syntax is illustrated below. You provide a comma separated list of name-value pairs separated with `=` within curly brackets:

```csharp
public class Person
{
    public string Name;
    public string Address;
}

var person = new Person{Name="The President", Address = "Élysée Palace"};
```

Collections can also be initialized in this way. Typically, this is accomplished with comma separated lists as shown here:

```csharp
IList<Person> people = new List<Person>{ new Person(), new Person{Name="Joe Shmo"}};
```

Dictinaries use the following syntax:

```csharp
IDictionary<int, string> numbers = new Dictionary<int, string>{ [0] = "zero", [1] = "one"...};

// or

IDictionary<int, string> numbers = new Dictionary<int, string>{ {0, "zero" }, {1,  "one"}...};
```

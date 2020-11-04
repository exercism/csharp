In this exercise you'll be writing code to print name badges for factory employees.

## 1. Print a badge for an employee

Employees have an ID, name and department name. Employee badge labels are formatted as follows: `"[id] - [name] - [DEPARTMENT]"`. Implement the (_static_) `Badge.Print()` method to return an employee's badge label:

```csharp
Badge.Print(734, "Ernest Johnny Payne", "Strategic Communication");
// => "[734] - Ernest Johnny Payne - STRATEGIC COMMUNICATION"
```

Note that the department should be uppercased on the label.

## 2. Print a badge for a new employee

Due to a quirk in the computer system, new employees occasionally don't yet have an ID when they start working at the factory. As badges are required, they will receive a temporary badge without the ID prefix. Modify the (_static_) `Badge.Print()` method to support new employees that don't yet have an ID:

```csharp
Badge.Print(id: null, "Jane Johnson", "Procurement");
// => "Jane Johnson - PROCUREMENT"
```

## 3. Print a badge for the owner

Even the factory's owner has to wear a badge at all times. However, an owner does not have a department. In this case, the label should print `"OWNER"` instead of the department name. Modify the (_static_) `Badge.Print()` method to print a label for the owner:

```csharp
Badge.Print(254, "Charlotte Hale", department: null);
// => "[254] - Charlotte Hale - OWNER"
```

Note that it is possible for the owner to also be a new employee:

```csharp
Badge.Print(id: null, "Charlotte Hale", department: null);
// => "Charlotte Hale - OWNER"
```

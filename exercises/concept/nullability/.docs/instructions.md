In this exercise you'll be writing code to helping printing name
badges for factory employees.

Employees have an ID, name and department name. Badge labels are
formatted as follows: `"[id] - [name] - [DEPARTMENT]"`

### 1. Generate an employee's badge label

Implement the `Badge.Label()` method to return an employee's badge label:

```csharp
Badge.Label(734, "Ernest Johnny Payne", "Strategic Communication");
// => "[734] - Ernest Johnny Payne - STRATEGIC COMMUNICATION"
```

### 2. Handle the optional parts of a badge label

The ID and department name are optional. If someone does not have an
ID, do not print this part of the label.  If someone has no
department, just print `GUEST` as their department name.

### 3. Generate the actual text to be print on the badge

Implement the `Badge.PrintLabel()` method to return an employee's
badge label that can fit on a badge with a given width. An optional
prefix may be added on the beginning of each line:

```csharp
Badge.PrintLabel(" > ", "[734] - Ernest Johnny Payne - STRATEGIC COMMUNICATION", 30);
// => " > [734] - Ernest Johnny Payne - \n> STRATEGIC COMMUNICATION"
// 
// => Printed label:
//
// > [734] - Ernest Johnny Payne - 
// > STRATEGIC COMMUNICATION

```

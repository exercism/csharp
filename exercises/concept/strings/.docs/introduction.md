A `string` in C# is an object that represents immutable text as a sequence of Unicode characters (letters, digits, punctuation, etc.). Double quotes are used to define a `string` instance:

```csharp
string fruit = "Apple";
```

Strings are manipulated by calling the string's methods. Once a string has been constructed, its value can never change. Any methods that appear to modify a string will actually return a new string.

Multiple strings can be concatenated (added) together. The simplest way to achieve this is by using the `+` operator.

```csharp
string name = "Jane";
"Hello " + name + "!";
// => "Hello Jane!"
```

For any string formatting more complex than simple concatenation, string interpolation is preferred. To use interpolation in a string, prefix it with the dollar (`$`) symbol. Then you can use curly braces (`{}`) to access any variables inside your string.

```csharp
string name = "Jane";
$"Hello {name}!";
// => "Hello Jane!"
```

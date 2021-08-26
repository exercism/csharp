# About

To allow an object to be compared to another object, it must implement the `IComparable<T>` interface.
This interface has a single method that needs to be implemented: `int CompareTo(T other)`.

There are three possible return values for the `CompareTo` method:

- Value smaller than zero: the current object is smaller than the other object.
- Value greater than zero: the current object is greater than the other object.
- Value is zero: the current object is equal to the other object.

```csharp
public class Book : IComparable<Book>
{
    public int PageCount { get; set; }

    public int CompareTo(Book other)
    {
        // If other is not a valid object reference, this instance is greater.
        if (other == null) return 1;

        // Compare books using their number of pages
        return PageCount.CompareTo(other.PageCount);
    }
}

var smallBook = new Book { PageCount = 99 };
var largeBook = new Book { PageCount = 3333 };

smallBook.CompareTo(largeBook);
// => -1
```

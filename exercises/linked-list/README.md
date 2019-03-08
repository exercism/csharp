# Linked List

Implement a doubly linked list.

Like an array, a linked list is a simple linear data structure. Several
common data types can be implemented using linked lists, like queues,
stacks, and associative arrays.

A linked list is a collection of data elements called *nodes*. In a
*singly linked list* each node holds a value and a link to the next node.
In a *doubly linked list* each node also holds a link to the previous
node.

You will write an implementation of a doubly linked list. Implement a
Node to hold a value and pointers to the next and previous nodes. Then
implement a List which holds references to the first and last node and
offers an array-like interface for adding and removing items:

* `push` (*insert value at back*);
* `pop` (*remove value at back*);
* `shift` (*remove value at front*).
* `unshift` (*insert value at front*);

To keep your implementation simple, the tests will not cover error
conditions. Specifically: `pop` or `shift` will never be called on an
empty list.

If you want to know more about linked lists, check [Wikipedia](https://en.wikipedia.org/wiki/Linked_list).

## Running the tests

To run the tests, run the command `dotnet test` from within the exercise directory.

Initially, only the first test will be enabled. This is to encourage you to solve the exercise one step at a time.
Once you get the first test passing, remove the `Skip` property from the next test and work on getting that test passing.
Once none of the tests are skipped and they are all passing, you can submit your solution 
using `exercism submit LinkedList.cs`

## Further information

For more detailed information about the C# track, including how to get help if
you're having trouble, please visit the exercism.io [C# language page](http://exercism.io/languages/csharp/resources).

## Source

Classic computer science topic


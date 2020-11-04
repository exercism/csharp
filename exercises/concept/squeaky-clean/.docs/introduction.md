The C# `char` type is a 16 bit quantity to represent the smallest addressable components of text.
Multiple `char`s can comprise a string such as `"word"` or `char`s can be
processed independently. Their literals have single quotes e.g. `'A'`.

C# `char`s support UTF-16 Unicode encoding so in addition to the latin character set
pretty much all the writing systems in use world can be represented,
e.g. ancient greek `'β'`.

There are many builtin library methods to inspect and manipulate `char`s. These
can be found as static methods of the `System.Char` class.

`char`s are sometimes used in conjunction with a `StringBuilder` object.
This object has methods that allow a string to be constructed
character by character and manipulated. At the end of the process
`ToString` can be called on it to output a complete string.

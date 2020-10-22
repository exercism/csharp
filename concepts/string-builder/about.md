Using `StringBuilder` is seen as hugely preferable to building up strings with multiple repeated concatenations with
a `+` or `+=` operator. Obviously simple one off concatenations are preferable
to instantiating a `StringBuilder` for clarity as well as performance. [This][skeet-stringbuilder] is what [Jon Skeet][so-jon-skeet] has to say about performance.

[skeet-stringbuilder]: https://jonskeet.uk/csharp/stringbuilder.html
[so-jon-skeet]: https://stackoverflow.com/users/22656/jon-skeet

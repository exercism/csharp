# [C#] Add new reference document: readonly vs const

This issue describes how to add a new [C# reference document][reference]: readonly vs const.

## Description

The goal of the new reference document is to explain the different between (`static`) `readonly` fields versus `const` fields, which is confusing to many students.

The document should explain how the two approaches are different, taking into account:

- What values they can be applied to.
- Readability aspects.
- Performance characteristics.
- Memory aspects.
- Generated IL code (optional).

Based on the aforementioned differences, the document should provide guidance on when to use which approach and why.

## Resources to refer to

- [StackOverflow - static readonly vs const][stackoverflow.com]

## Contributing

To create the reference, please:

- [Create the document at `language/csharp/reference/readonly-vs-const.md`][new-document].
- Remove the corresponding TODO item in the [reference README][reference].
- Add a link to the reference document in the [reference README][reference].

[stackoverflow.com]: https://stackoverflow.com/questions/755685/static-readonly-vs-const#755693
[reference]: https://github.com/exercism/v3/blob/master/languages/csharp/reference/README.md#reference-docs
[new-document]: https://github.com/exercism/v3/new/master?filename=languages/csharp/reference/readonly-vs-const.md

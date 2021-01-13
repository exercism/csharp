# Code style

While the C# compiler doesn't enforce a particular code style, there are general [coding conventions][docs.microsoft.com_coding-conventions] and [design guidelines][docs.microsoft.com_design-guidelines].

## Formatting conventions

The C# formatting formatting conventions are defined in the [layout conventions][docs.microsoft.com_layout-conventions].

## Naming conventions

Broadly speaking, the C# naming conventions are as follows:

- PascalCase for types, methods and constants.
- camelCase for fields, variables and parameters.

These conventions are described in the [.NET capitalization conventions][docs.microsoft.com_capitalization-conventions] and the [.NET general naming conventions][docs.microsoft.com_general-naming-conventions].

## Other conventions

### Prefer type alias

The general consensus is to prefer the C# type over the .NET type. Here are some examples where this prefererence shows:

- The default [C# editorconfig settings][docs.microsoft.com_editorconfig-language-keywords].
- The [ReSharper built-in type naming rule][jetbrains.com_built-in-type-naming].
- The [CoreFX coding style document][github.com_corefx-coding-style].

## Enforcing code style

It is possible to encode C# coding style conventions using [`.editorconfig files`][docs.microsoft.com_editorconfig]. This includes being able to specify [formatting conventions][docs.microsoft.com_editorconfig-formatting-conventions] and [naming conventions][docs.microsoft.com_editorconfig-naming-conventions].

Most C# IDE's have support for `.editorconfig` files, including Visual Studio 2019+, Rider and VS Code (using the C# extension).

The [dotnet format global tool][github.com_dotnet-format-editorconfig-options] can be run as a [command-line tool][github.com_dotnet-format-how-to] and has support for a [limited set of the `.editorconfig` settings][github.com_dotnet-format-editorconfig-options].

[docs.microsoft.com_design-guidelines]: https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/
[docs.microsoft.com_coding-conventions]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions
[docs.microsoft.com_capitalization-conventions]: https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/capitalization-conventions
[docs.microsoft.com_general-naming-conventions]: https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/general-naming-conventions
[docs.microsoft.com_layout-conventions]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions#layout-conventions
[docs.microsoft.com_editorconfig]: https://docs.microsoft.com/en-us/visualstudio/ide/create-portable-custom-editor-options?view=vs-2019
[docs.microsoft.com_editorconfig-formatting-conventions]: https://docs.microsoft.com/en-us/visualstudio/ide/editorconfig-formatting-conventions?view=vs-2019
[docs.microsoft.com_editorconfig-naming-conventions]: https://docs.microsoft.com/en-us/visualstudio/ide/editorconfig-naming-conventions?view=vs-2019
[github.com_dotnet-format]: https://github.com/dotnet/format/blob/master/README.md
[github.com_dotnet-format-editorconfig-options]: https://github.com/dotnet/format/wiki/Supported-.editorconfig-options
[github.com_dotnet-format-how-to]: https://github.com/dotnet/format/blob/master/README.md#how-to-install
[docs.microsoft.com_editorconfig-language-keywords]: https://docs.microsoft.com/en-us/visualstudio/ide/editorconfig-language-conventions?view=vs-2019#language-keywords
[github.com_corefx-coding-style]: https://github.com/dotnet/runtime/blob/master/docs/coding-guidelines/coding-style.md
[jetbrains.com_built-in-type-naming]: https://www.jetbrains.com/help/resharper/Built_In_Type_Naming.html

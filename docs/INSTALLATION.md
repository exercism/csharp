# Installation

## Installing .NET

The F# track is built on top of the [.NET](https://dotnet.microsoft.com/learn/dotnet/what-is-dotnet) platform, which runs on Windows, Linux and macOS. To build .NET projects, you can use the .NET Command Line Interface (CLI). This CLI is part of the .NET SDK, which you can install by following the [installation instructions](https://dotnet.microsoft.com/download/dotnet/5.0). Note: the F# track requires SDK version 5.0 or greater.

After completing the installation, you can verify if the CLI was installed succesfully by running this command in a terminal:

```bash
dotnet --version
```

It the output is a version greater than or equal to `5.0.100`, the .NET SDK has been installed succesfully.

## Using an IDE

If you want a more full-featured editing experience, you probably want to to use an IDE. These are the most popular IDE's that support building .NET projects:

- [Visual Studio 2019](https://www.visualstudio.com/downloads/)
- [Visual Studio Code](https://code.visualstudio.com/download) with the [Ionide-fsharp extension](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-fsharp)
- [Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/)
- [Project Rider](https://www.jetbrains.com/rider/download/)

Note: as the .NET project format differs significantly from earlier versions, older IDE's (like Visual Studio 2015) are not supported.

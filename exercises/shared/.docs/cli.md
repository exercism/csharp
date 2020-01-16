# CLI

You can run the tests by opening a command prompt in the exercise's directory, and then running the [`dotnet test` command][docs-dotnet-test]. Alternatively, most IDE's have built-in support for running tests, including [Visual Studio][docs-run-unit-tests-visual-studio], [Rider][docs-run-unit-tests-rider] and [Visual Studio code][docs-run-unit-tests-visual-studio-code].

Initially, only the first test will be enabled. This is to encourage you to solve the exercise one step at a time. Once you get the first test passing, remove the `Skip` property from the next test and work on getting that test passing.

Once none of the tests are skipped and they are all passing, you can submit your solution by opening a command prompt in the exercise's directory and running the [`exercism submit` command][docs-exercism-cli].

[docs-dotnet-test]: https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test?tabs=netcore21
[docs-exercism-cli]: https://exercism.io/cli
[docs-run-unit-tests-visual-studio]: https://docs.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer?view=vs-2019
[docs-run-unit-tests-visual-studio-code]: https://github.com/OmniSharp/omnisharp-vscode/wiki/How-to-run-and-debug-unit-tests
[docs-run-unit-tests-rider]: https://www.jetbrains.com/help/rider/Unit_Testing_in_Solution.html

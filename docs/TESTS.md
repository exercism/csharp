## Running Tests

To run the tests, you first need to restore the project's dependencies using the following command:

```bash
dotnet restore
```

You can then run the tests by executing the following command:

```bash
dotnet test
```

Note: if the .NET CLI fails to detect your latest source code changes, please run the following command before running `dotnet test`:

```bash
dotnet clean
```

## Solving the exercise

Solving an exercise means making all its tests pass. By default, only one test (the first one) is executed when you run the tests. This is intentional, as it allows you to focus on just making that one test pass. Once it passes, you can enable the next test by removing `Skip = "Remove to run test"` from the test's `[Fact]` or `[Theory]` attribute. When all tests have been enabled and your implementation makes them all pass, you'll have solved the exercise!

To help you get started, each exercise comes with a stub implementation file. You can use this file as a starting point for building your solution. Feel free to remove or change this file if you think it is the right thing to do.

## Using packages

You should be able to solve most exercises without using any external packages. However, for the exercises where you do want to use an external package, you can add it to your project by running the following command:

```bash
dotnet add package <package-name>
```

Once the package has been added, you need to update the project's dependencies again to use it in your project:

```bash
dotnet restore
```

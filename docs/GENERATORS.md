# Test Generators

Test generators allow tracks to generate tests automatically without having to write them ourselves. Each test generator reads from the exercise's `canonical data`, which defines the name of the test, its inputs, and outputs. You can read more about exercism's approach to test suites [here](https://github.com/exercism/docs/blob/master/language-tracks/exercises/anatomy/test-suites.md).

Generating tests automatically removes any sort of user error when creating tests. We want the tests to be accurate with respect to its canonical data. Test generation also makes it much easier to keep tests up to date. As the canonical data changes, the tests will be automatically updated when the generator for that test is run.

An example of a canonical data file can be found [here](https://github.com/exercism/problem-specifications/blob/master/exercises/bob/canonical-data.json)

## Common Terms
When looking through the canonical data and the generator code base, we use a lot of common terminology. This list hopefully clarifies what they represent.

- Canonical Data - Represents the entire test suite.
- Canonical Data Case - A representation of a single test case.
- Description - The name of the test.
- Property - The method to be called when running the test.
- Input - The input for the test case.
- Expected - The expected value when running the test case.

## Adding A Simple Generator
Adding a test generator file is straightforward. Simply add a new file to the generators folder with the name of the exercise (in PascalCase), and extend the `GeneratorExercise` abstract class.

An example of a simple generator would be the Bob exercise. The source is below, but you can freely view it in the repository [here](https://github.com/exercism/csharp/blob/master/generators/Exercises/Bob.cs).

```csharp
namespace Generators.Exercises
{
    public class Bob : GeneratorExercise
    {
    }
}
```

This is a fully working generator, no other code needs to be written. However, it's simplicity stems from the fact that the test suite and the program itself are relatively trivial.

## Adding A Complex Generator

A more *complex* generator would be the ComplexNumbers generator found [here](https://github.com/exercism/csharp/blob/master/generators/Exercises/ComplexNumbers.cs).

The `GeneratorExercise` abstract class currently exposes five methods that are used for overriding the default behavior when generating an exercise.

### void UpdateCanonicalData(CanonicalData canonicalData)
Update the canonical data for a given test. 

The most common use for this override is to iterate over each of the canonical data cases.

As an example, if you wanted to change the default behavior so that when the `Input` value of a test is a negative number, an exception should be thrown, the code would look like this.

```csharp
protected override void UpdateCanonicalData(CanonicalData canonicalData)
{
  foreach (var canonicalDataCase in canonicalData.Cases)
  {
    var caseInputLessThanZero = (long)canonicalDataCase.Input["number"] < 0;
    canonicalDataCase.ExceptionThrown = caseInputLessThanZero ? typeof(ArgumentException) : null;
  }
}
```

### HashSet\<string\> AddAdditionalNamespaces()
Allows more namespaces to be added to the test suite. 

The tests use `Xunit` so all tests will automatically include the `Xunit` namespace. However, more advanced tests may require additional namespaces.

```csharp
protected override HashSet<string> AddAdditionalNamespaces()
{
  return new HashSet<string>()
  {
    typeof(Dictionary<char, int>).Namespace
  };
}
```

This snippet would add the namespace that the `Dictionary<char, int>` collection lives in (`System.Collections.Generic`).

### string RenderTestMethodBody[Arrange/Act/Assert]
Override the default behavior when rendering a test methods arrange, act, and/or assert sections.

More advanced tests may need to leverage a `template`. A template allows you to add additional code to a test and assert more complex statements.

An example of this is the [RunLengthEncoding](https://github.com/exercism/csharp/blob/master/generators/Exercises/RunLengthEncoding.cs) test.

Here the **Assert** is being overridden. The assert needs to call additional functions, but only if the property is `consistency`. Otherwise, render the assert as usual.

### string[] RenderAdditionalMethods()
Allow additional methods to be added to the test suite.

There may exist cases where a suite of unit tests will need to reuse the same logic in each of the tests. Rather than duplicating code, this method allows you to provide helper methods for the tests.

An example of this is the [Tournament](https://github.com/exercism/csharp/blob/master/generators/Exercises/Tournament.cs#L45) generator.

Additional methods added using this override will be added to the bottom of the test suite.

## Updating Existing Files
It is possible that an existing exercise does not match the canonical data. It is OK to update the exercise stub and/or the exercise example to follow the canonical data! An example might be that an exercise is named SumOfMultiples, but the SumOfMultiples.cs and Example.cs files both use `Multiples` as the name of the class.

Also, if you find an issue with one of the existing generators or test suites simply open up the generator that you would like to update, make your changes, and then run the generators.

## Running The Generators
This repository is coded against [.NET Core](https://www.microsoft.com/net/core). To run the generators all you need to do is run the following command in the generators directory:

`dotnet run`

This command will take all of the generators that are in the `Exercises` folder, and generate all of the test cases for that exercise. We use reflection to get all of the exercises, so if you are adding a new test, the test will be automatically included when running the generator.

If you only need to run a single generator, you can do so by running the following command:

`dotnet run -e <exercise>`

Once the generator has been run, you can view the output of your generation by navigating to the test file for that exercise. As an example, the test suite for the Bob exercise can be found at:

`exercises/bob/BobTest.cs`

## Submitting A Generator
If you are satisfied with the output of your generator, we would love for you to submit a pull request! Please include your generator, updated test suite, and any other corresponding files that you may have changed.

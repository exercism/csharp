# Test generators

Test generators allow tracks to generate tests automatically without having to write them ourselves. Each test generator reads from the exercise's `canonical data`, which defines the name of the test, its inputs, and outputs. You can read more about exercism's approach to test suites [here](https://github.com/exercism/problem-specifications#test-data-canonical-datajson).

Generating tests automatically removes any sort of user error when creating tests. Furthermore, we want the tests to be accurate with respect to its canonical data. Test generation also makes it much easier to keep tests up to date. As the canonical data changes, the tests will be automatically updated when the generator for that test is run.

An example of a canonical data file can be found [here](https://github.com/exercism/problem-specifications/blob/master/exercises/bob/canonical-data.json)

## Common terms

When looking through the canonical data and the generator code base, we use a lot of common terminology. This list hopefully clarifies what they represent.

- Canonical Data - Represents the entire test suite.
- Canonical Data Case - A representation of a single test case.
- Description - The name of the test.
- Property - The method to be called when running the test.
- Input - The input for the test case.
- Expected - The expected value when running the test case.

## Adding a simple generator

Adding a test generator is straightforward. Simply add a new file to the `Exercises/Generators` folder with the name of the exercise (in PascalCase), and create a class that extends the `GeneratorExercise` class.

An example of a simple generator would be the Bob exercise. The source is displayed below, but you can freely view it in the repository [here](https://github.com/exercism/csharp/blob/main/generators/Exercises/Generators/Bob.cs).

```csharp
namespace Exercism.CSharp.Exercises.Generators
{
    public class Bob : GeneratorExercise
    {
    }
}
```

This is a fully working generator, no other code needs to be written! However, it's simplicity stems from the fact that the test suite and the program itself are relatively trivial.

## Adding a complex generator

When the generator's default output is not sufficient, you can override the `GeneratorExercise` class' virtual methods to override the default behavior.

### Method 1: UpdateTestMethod(TestMethod testMethod)

Update the test method that described the test method being generated. When you are required to customize a test generator, overriding this method is virtually always what you want to do.

There are many things that can be customized, of which we'll list the more common usages.

#### Customize test data

It is not uncommon that a generator has to transform its input data or expected value to a different value/representation.

An example of this is the [matching-brackets](https://github.com/exercism/csharp/blob/main/generators/Exercises/Generators/MatchingBrackets.cs) generator, which has a `"value"` input value, which is of type `string`. However, this `string` value contains a backslash, which needs to escaped in order for it to be rendered correctly:

```csharp
protected override void UpdateTestMethod(TestMethod testMethod)
{
    testMethod.Input["value"] = testMethod.Input["value"].Replace("\\", "\\\\");
    // [...]
}
```

Another common use case is to handle empty arrays. If an array is empty, its type will default to `JArray`, which doesn't have any type information. To allow the generator to output a correctly typed array, we have to convert the `JArray` to an array first.

An example of this is the [proverb](https://github.com/exercism/csharp/blob/main/generators/Exercises/Generators/Proverb.cs) generator, which converts the `JArray` to an empty `string` array:

```csharp
protected override void UpdateTestMethod(TestMethod testMethod)
{
    // [...]

    if (testMethod.Input["strings"] is JArray)
        testMethod.Input["strings"] = Array.Empty<string>();

    if (testMethod.Expected is JArray)
        testMethod.Expected = Array.Empty<string>();
}
```

#### Output test data as variables

Sometimes, it might make sense to not define a test method's data inline, but as variables.

An example of this is the [crypto-square](https://github.com/exercism/csharp/blob/main/generators/Exercises/Generators/CryptoSquare.cs) generator, which indicates that both the test method input as well as the expected value, should be stored in variables:

```csharp
protected override void UpdateTestMethod(TestMethod testMethod)
{
    testMethod.UseVariablesForInput = true;
    testMethod.UseVariableForExpected = true;
}
```

#### Custom tested method type

By default, the generator will test a static method. However, you can also test for instance methods, extension methods, properties and constructors.

An example of this is the [roman-numerals](https://github.com/exercism/csharp/blob/main/generators/Exercises/Generators/RomanNumerals.cs) generator, which indicates that it tests an extensions method:

```csharp
protected override void UpdateTestMethod(TestMethod testMethod)
{
    testMethod.TestedMethodType = TestedMethodType.ExtensionMethod;
    testMethod.TestedMethod = "ToRoman";
}
```

#### Change names used

As we saw in the previous example, you can also customize the name of the tested method. You are also allowed to customize the tested class' name and the test method name.

An example of this is the [triangle](https://github.com/exercism/csharp/blob/main/generators/Exercises/Generators/Triangle.cs) generator, which by default generates duplicate test method names (which will be a compile-time error), but instead uses the `TestMethodNameWithPath` to use the full path as the test method name (effectively making the test method name unique):

```csharp
protected override void UpdateTestMethod(TestMethod testMethod)
{
    // [...]
    testMethod.TestMethodName = testMethod.TestMethodNameWithPath;
    // [...]
}
```

#### Test for an exception being thrown

Some test methods want to verify that an exception is being thrown.

An example of this is the [rna-transcription](https://github.com/exercism/csharp/blob/main/generators/Exercises/Generators/RnaTranscription.cs) generator, which defines that some of its test methods should throw an `ArgumentException`:

```csharp
protected override void UpdateTestMethod(TestMethod testMethod)
{
    if (testMethod.Expected is null)
        testMethod.ExceptionThrown = typeof(ArgumentException);
}
```

Note that `ArgumentException` type's namespace will be automatically added to the list of namespaces used in the test class.

#### Custom input/constructor parameters

In some cases, you might want to override the parameters that are used as input parameters.

An example of this is the [two-fer](https://github.com/exercism/csharp/blob/main/generators/Exercises/Generators/TwoFer.cs) generator, which does not use any input parameters when the `"name"` input parameter is set to `null`:

```csharp
protected override void UpdateTestMethod(TestMethod testMethod)
{
  // [...]

  if (testMethod.Input["name"] is null)
    testMethod.InputParameters = Array.Empty<string>();
}
```

If a test method tests an instance method, you can also specify which parameters to use as constructor parameters (the others will be input parameters, unless specified otherwise).

An example of this is the [matrix](https://github.com/exercism/csharp/blob/main/generators/Exercises/Generators/Matrix.cs) generator, which specifies that the `"string"` parameter should be passed as a constructor parameter:

```csharp
protected override void UpdateTestMethod(TestMethod testMethod)
{
  testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
  testMethod.ConstructorInputParameters = new[] { "string" };
}
```

#### Custom arrange/act/assert code

Although this should be used as a last resort, some generators might want to skip the default generation completely and control which arrange, act or assert code the test method should contain.

An example of this is the [run-length-encoding](https://github.com/exercism/csharp/blob/main/generators/Exercises/Generators/RunLengthEncoding.cs) generator, which uses a custom assertion for one specific property:

```csharp
protected override void UpdateTestMethod(TestMethod testMethod)
{
    // [...]

    if (testMethod.Property == "consistency")
        testMethod.Assert = RenderConsistencyToAssert(testMethod);
}

private string RenderConsistencyToAssert(TestMethod testMethod)
{
    var expected = Render.Object(testMethod.Expected);
    var actual = $"{testMethod.TestedClass}.Decode({testMethod.TestedClass}.Encode({expected}))";
    return Render.AssertEqual(expected, actual);
}
```

Note that the `Render` instance is used to render the assertion and the expected value.

### Method 2: UpdateNamespaces(ISet<string> namespaces)

Allows additional namespaces to be added to the test suite.

All tests use the `Xunit` framework, so each test class will automatically include the `Xunit` namespace. However, some test classes may require additional namespaces.

An example of this is the [gigasecond](https://github.com/exercism/csharp/blob/main/generators/Exercises/Generators/Gigasecond.cs) generator, which uses the `DateTime` class in its test methods, and thus adds its namespace to the list of namespaces:

```csharp
protected override void UpdateNamespaces(ISet<string> namespaces)
{
    namespaces.Add(typeof(DateTime).Namespace);
}
```

Note that as mentioned before, the namespace of any thrown exception types are automatically added to the list of namespaces.

### Method 3: UpdateTestClass(TestClass testClass)

This method allows you to customize the output of the test class. Only in rare cases would you want to override this method. The most common use case to override this method, is to add additional (helper) methods to the test suite.

An example of this is the [tournament](https://github.com/exercism/csharp/blob/main/generators/Exercises/Generators/Tournament.cs) generator, which adds a helper method to the test suite:

```csharp
protected override void UpdateTestClass(TestClass testClass)
{
    AddRunTallyMethod(testClass);
}

private static void AddRunTallyMethod(TestClass testClass)
{
    testClass.AdditionalMethods.Add(@"
private string RunTally(string input)
{
  var encoding = new UTF8Encoding();

  using (var inStream = new MemoryStream(encoding.GetBytes(input)))
  using (var outStream = new MemoryStream())
  {
    Tournament.Tally(inStream, outStream);
    return encoding.GetString(outStream.ToArray());
  }
}");
}
```

Additional methods will be added to the bottom of the test suite.

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

`exercises/bob/BobTests.cs`

## Submitting A Generator

If you are satisfied with the output of your generator, we would love for you to submit a pull request! Please include your generator, updated test suite, and any other corresponding files that you may have changed.

namespace Generators;

using Humanizer;

internal class PerfectNumbersTestCaseTransformer : TestCaseTransformer
{
    protected override TestCase UpdateTestCase(TestCase testCase) =>
        testCase.Error is null
            ? testCase with { Expected = $"Classification.{((string)testCase.Expected.ToString()).Pascalize()}" }
            : testCase;
}

internal static class TestCaseTransformerFactory
{
    internal static TestCaseTransformer Create(Exercise exercise) =>
        exercise.Slug switch
        {
            "perfect-numbers" => new PerfectNumbersTestCaseTransformer(),
            _ => new TestCaseTransformer()
        };
}

class TestCaseTransformer
{
    protected virtual TestCase UpdateTestCase(TestCase testCase) => testCase;

    protected virtual TestCase[] AddOrRemoveTestCases(TestCase[] testCases) => testCases;

    public static TestCase[] Transform(Exercise exercise, TestCase[] testCases) =>
        TestCaseTransformerFactory.Create(exercise).AddOrRemoveTestCases(testCases)
            .Select(TestCaseTransformerFactory.Create(exercise).UpdateTestCase)
            .ToArray();
}

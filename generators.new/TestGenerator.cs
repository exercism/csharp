namespace Generators;

internal static class TestGenerator
{
    internal static void GenerateTests(Exercise exercise)
    {
        Console.WriteLine($"{exercise.Slug}: generating tests...");
        
        var excludedTestCaseIds = TestCaseConfiguration.ExcludedTestCaseIds(exercise);
        var testCases = CanonicalData.Parse(exercise)
            .Where(testCase => !excludedTestCaseIds.Contains(testCase.Uuid))
            .ToArray();

        var renderedTests = Templates.RenderTests(exercise, testCases);
        File.WriteAllText(Paths.TestsFile(exercise), Formatting.FormatCode(renderedTests));
    }
}
namespace Generators;

internal static class TestGenerator
{
    internal static void GenerateTestsFromTemplate(Exercise exercise)
    {
        Console.WriteLine($"{exercise.Slug}: generating tests...");
        
        var excludedTestCaseIds = TestsToml.ExcludedTestCaseIds(Paths.TestsTomlFile(exercise));
        var testCases = CanonicalData.Parse(Paths.CanonicalDataFile(exercise))
            .Where(testCase => !excludedTestCaseIds.Contains(testCase.Uuid))
            .ToArray();

        var renderedTests = TemplateRenderer.RenderTests(exercise, testCases);
        File.WriteAllText(Paths.TestsFile(exercise), Formatter.FormatCode(renderedTests));
    }
}
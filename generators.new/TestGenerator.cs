namespace Generators;

internal static class TestGenerator
{
    internal static void GenerateTestsFromTemplate(Exercise exercise)
    {
        Console.WriteLine($"{exercise.Slug}: generating tests...");
        
        var excludedTestCaseIds = TestsToml.ExcludedTestCaseIds(exercise);
        var testCases = CanonicalData.Parse(exercise)
            .Where(testCase => !excludedTestCaseIds.Contains(testCase.Uuid))
            .ToArray();

        var transformedTestCases = TestCaseTransformer.Transform(exercise, testCases);

        var renderedTests = TemplateRenderer.RenderTests(exercise, transformedTestCases);
        File.WriteAllText(Paths.TestsFile(exercise), CodeFormatter.FormatCode(renderedTests));
    }
}
using Scriban;

internal record Exercise(string Slug, string Name);

public static class Program 
{
    static void Main()
    {
        foreach (var exercise in ExerciseFinder.TemplatedExercises())
            GenerateTestsFile(exercise);
        
        Console.WriteLine("Hello, World!");
    }

    private static void GenerateTestsFile(Exercise exercise)
    {
        var excludedTestCaseIds = TestsToml.ExcludedTestCaseIds(Paths.TestsTomlFile(exercise));
        var testCases = CanonicalData.Parse(Paths.CanonicalDataFile(exercise))
            .Where(testCase => !excludedTestCaseIds.Contains(testCase.Uuid))
            .ToArray();

        TemplateRenderer.Render(exercise, testCases);
    }
}

internal static class TemplateRenderer
{
    public static void Render(Exercise exercise, TestCase[] testCases)
    {
        var template = Template.Parse(File.ReadAllText(Paths.TemplateFile(exercise)));
        File.WriteAllText(Paths.TestsFile(exercise), template.Render(new { TestCases = testCases })!);
    }
}

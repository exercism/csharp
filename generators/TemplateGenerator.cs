namespace Generators;

internal static class TemplateGenerator
{
    internal static void Generate(Exercise exercise)
    {
        Console.WriteLine($"{exercise.Slug}: generating template...");
        
        var canonicalData = CanonicalDataParser.Parse(exercise);
        var filteredCanonicalData = TestCasesConfiguration.RemoveExcludedTestCases(canonicalData);

        var template = RenderTemplate(filteredCanonicalData);
        File.WriteAllText(Paths.TemplateFile(exercise), template);
    }

    private static string RenderTemplate(CanonicalData canonicalData) =>
        "test";
}
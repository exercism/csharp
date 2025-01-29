namespace Generators;

internal static class TestsGenerator
{
    internal static void Generate(Exercise exercise)
    {
        Console.WriteLine($"{exercise.Slug}: generating tests...");
        
        var canonicalData = CanonicalDataParser.Parse(exercise);
        var filteredCanonicalData = TestCasesConfiguration.RemoveExcludedTestCases(canonicalData);

        var testCode = Templates.RenderTestsCode(filteredCanonicalData);
        var formattedTestCode = Formatting.FormatCode(testCode);
        File.WriteAllText(Paths.TestsFile(exercise), formattedTestCode);
    }
}
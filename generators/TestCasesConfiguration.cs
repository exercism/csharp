using Tomlyn;
using Tomlyn.Model;

namespace Generators;

internal static class TestCasesConfiguration
{
    internal static CanonicalData RemoveExcludedTestCases(CanonicalData canonicalData)
    {
        var excludedTestCaseIds = ExcludedTestCaseIds(canonicalData.Exercise);
        var includedTestCases = canonicalData.TestCases
            .Where(testCase => !excludedTestCaseIds.Contains(testCase["uuid"]!.ToObject<string>()!))
            .ToArray();
        
        return canonicalData with { TestCases = includedTestCases };
    }

    private static HashSet<string> ExcludedTestCaseIds(Exercise exercise) =>
        Toml.ToModel(File.ReadAllText(Paths.TestsTomlFile(exercise)))
            .Where(IsExcluded)
            .Select(table => table.Key)
            .ToHashSet();

    private static bool IsExcluded(KeyValuePair<string, object> idTablePair) =>
        idTablePair.Value is TomlTable table &&
        table.TryGetValue("include", out var includeValue) &&
        includeValue is false;
}
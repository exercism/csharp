using Tomlyn;
using Tomlyn.Model;

namespace Generators;

internal static class TestsToml
{
    internal static HashSet<string> ExcludedTestCaseIds(string testsTomlFile) =>
        Toml.ToModel(File.ReadAllText(testsTomlFile))
            .Where(IsExcluded)
            .Select(table => table.Key)
            .ToHashSet();

    private static bool IsExcluded(KeyValuePair<string, object> idTablePair) =>
        idTablePair.Value is TomlTable table &&
        table.TryGetValue("include", out var includeValue) &&
        includeValue is false;
}
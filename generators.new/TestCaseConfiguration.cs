using Tomlyn;
using Tomlyn.Model;

namespace Generators;

internal static class TestCaseConfiguration
{
    internal static HashSet<string> ExcludedTestCaseIds(Exercise exercise) =>
        Toml.ToModel(File.ReadAllText(Paths.TestsTomlFile(exercise)))
            .Where(IsExcluded)
            .Select(table => table.Key)
            .ToHashSet();

    private static bool IsExcluded(KeyValuePair<string, object> idTablePair) =>
        idTablePair.Value is TomlTable table &&
        table.TryGetValue("include", out var includeValue) &&
        includeValue is false;
}
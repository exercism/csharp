using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Nodes;

using Humanizer;

using Tomlyn;
using Tomlyn.Model;

internal record Exercise(string Slug, string Name);

internal record TestCase(
    string Uuid,
    string Description,
    string Property,
    Dictionary<string, dynamic> Input,
    dynamic Expected);

internal static class CanonicalData
{
    internal static IEnumerable<TestCase> Parse(string canonicalDataFile) =>
        Parse(JsonNode.Parse(File.ReadAllText(canonicalDataFile))!.AsObject(), ImmutableStack<string>.Empty);

    internal static IEnumerable<TestCase> Parse(JsonObject jsonObject, ImmutableStack<string> path) =>
        jsonObject.TryGetPropertyValue("cases", out var cases)
            ? Parse(cases as JsonObject, path.Push(jsonObject["description"]!.ToString()))
            : [jsonObject.Deserialize<TestCase>()!];
}

internal static class TestsToml
{
    internal static HashSet<string> ExcludedTestCaseIds(Exercise exercise) =>
        Toml.ToModel(File.ReadAllText(Paths.TomlFile(exercise)))
            .Where(IsExcluded)
            .Select(table => table.Key)
            .ToHashSet();

    private static bool IsExcluded(KeyValuePair<string, object> idTablePair) =>
        idTablePair.Value is TomlTable table &&
        table.TryGetValue("include", out var includeValue) &&
        includeValue is false;
}

internal static class ExerciseFinder
{
    internal static IEnumerable<Exercise> TemplatedExercises() =>
        Directory.EnumerateFiles(Paths.PracticeExercisesDir, "Generator.tpl", SearchOption.AllDirectories)
            .Select(templateFile => Directory.GetParent(templateFile)!.Parent!.Name)
            .Select(ToExercise);

    private static Exercise ToExercise(string slug) => new(slug, slug.Pascalize());
}

public static class Program 
{
    static void Main()
    {
        foreach (var exercise in ExerciseFinder.TemplatedExercises())
        {
            Console.WriteLine(exercise);
        }
        
        Console.WriteLine("Hello, World!");
    }
}

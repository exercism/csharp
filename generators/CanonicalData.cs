using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Nodes;

using LibGit2Sharp;

namespace Generators;

internal record CanonicalData(Exercise Exercise, JsonNode[] TestCases);

internal static class CanonicalDataParser
{
    static CanonicalDataParser() => ProbSpecs.Sync();
    
    internal static CanonicalData Parse(Exercise exercise) => new(exercise, ParseTestCases(exercise));

    private static JsonNode[] ParseTestCases(Exercise exercise) =>
        ParseTestCases(ParseCanonicalData(exercise), ImmutableQueue<string>.Empty).ToArray();

    private static JsonNode ParseCanonicalData(Exercise exercise) =>
        JsonNode.Parse(File.ReadAllText(Paths.CanonicalDataFile(exercise)))!;

    private static IEnumerable<JsonNode> ParseTestCases(JsonNode jsonNode, ImmutableQueue<string> path)
    {
        var updatedPath = jsonNode["description"] is {} description
            ? path.Enqueue(description.GetValue<string>())
            : path;

        return jsonNode["cases"] is {} cases
            ? cases.AsArray().SelectMany(child => ParseTestCases(child!, updatedPath))
            : [ToTestCase(jsonNode, updatedPath)];
    }

    private static JsonNode ToTestCase(JsonNode testCaseJson, IEnumerable<string> path)
    {
        testCaseJson["path"] = JsonSerializer.SerializeToNode(path);
        return testCaseJson;
    }
    
    private static class ProbSpecs
    {
        internal static void Sync()
        {
            Clone();
            Pull();
        }

        private static void Clone()
        {
            if (!Directory.Exists(Paths.ProbSpecsDir))
                Repository.Clone("https://github.com/exercism/problem-specifications.git", Paths.ProbSpecsDir);
        }

        private static void Pull()
        {
            using var repo = new Repository(Paths.ProbSpecsDir);
            Commands.Pull(repo, new Signature("Exercism", "info@exercism.org", DateTimeOffset.Now), new PullOptions());
        }
    }
}


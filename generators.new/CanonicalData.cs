using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Nodes;

using LibGit2Sharp;

using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Generators;

internal record TestCase(
    string Uuid,
    string Description,
    string Property,
    Dictionary<string, dynamic> Input,
    dynamic Expected,
    dynamic Error,
    string[] Path);

internal static class CanonicalData
{
    private static readonly JsonSerializerOptions SerializerOptions = new() { PropertyNameCaseInsensitive = true };

    static CanonicalData() => ProbSpecs.Sync();

    internal static TestCase[] Parse(Exercise exercise) =>
        Parse(JsonNode.Parse(File.ReadAllText(Paths.CanonicalDataFile(exercise)))!.AsObject(), ImmutableQueue<string>.Empty)
            .ToArray();

    private static IEnumerable<TestCase> Parse(JsonObject jsonObject, ImmutableQueue<string> path)
    {
        var updatedPath = jsonObject.TryGetPropertyValue("description", out var description)
            ? path.Enqueue(description.Deserialize<string>()!)
            : path;
        
        return jsonObject.TryGetPropertyValue("cases", out var cases)
            ? cases!.AsArray().SelectMany(child => Parse(child!.AsObject(), updatedPath))
            : [ToTestCase(jsonObject, updatedPath)];
    }

    private static TestCase ToTestCase(JsonObject testCaseJson, IEnumerable<string> path)
    {
        testCaseJson["path"] = JsonValue.Create(path);
        testCaseJson["error"] = ToError(testCaseJson);
        return testCaseJson.Deserialize<TestCase>(SerializerOptions)!;
    }

    private static JsonNode? ToError(JsonObject testCaseJson)
    {
        if (testCaseJson["expected"] is JsonObject expectedJson &&
            expectedJson.TryGetPropertyValue("error", out var error))
            return error!.DeepClone();

        return null;
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


using System.Collections.Immutable;
using System.Dynamic;

using LibGit2Sharp;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Generators;

internal record TestCase(
    string Uuid,
    string Description,
    string Property,
    Dictionary<string, dynamic> Input,
    dynamic Expected,
    dynamic Error,
    string[] Path);

internal record CanonicalData(Exercise Exercise, TestCase[] TestCases);

internal static class CanonicalDataParser
{
    static CanonicalDataParser() => ProbSpecs.Sync();
    
    internal static CanonicalData Parse(Exercise exercise) => new(exercise, ParseTestCases(exercise));

    private static TestCase[] ParseTestCases(Exercise exercise)
    {
        var jsonObject = JObject.Parse(File.ReadAllText(Paths.CanonicalDataFile(exercise)));
        return ParseTestCases(jsonObject, ImmutableQueue<string>.Empty).ToArray();
    }

    private static IEnumerable<TestCase> ParseTestCases(JObject jsonObject, ImmutableQueue<string> path)
    {
        var updatedPath = jsonObject.TryGetValue("description", out var description)
            ? path.Enqueue(description.Value<string>()!)
            : path;

        return jsonObject.TryGetValue("cases", out var cases)
            ? ((JArray)cases).Cast<JObject>().SelectMany(child => ParseTestCases(child, updatedPath))
            : [ToTestCase(jsonObject, updatedPath)];
    }

    private static TestCase ToTestCase(JObject testCaseJson, IEnumerable<string> path)
    {
        testCaseJson["path"] = JArray.FromObject(path);
        testCaseJson["error"] = ToError(testCaseJson);
        return JsonConvert.DeserializeObject<TestCase>(testCaseJson.ToString())!;
    }

    private static JToken? ToError(JObject testCaseJson)
    {
        if (testCaseJson["expected"] is JObject expectedJson &&
            expectedJson.TryGetValue("error", out var error))
            return error.DeepClone();

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


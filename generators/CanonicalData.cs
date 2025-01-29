using System.Collections.Immutable;

using LibGit2Sharp;

using Newtonsoft.Json.Linq;

namespace Generators;

internal record CanonicalData(Exercise Exercise, JObject[] TestCases);

internal static class CanonicalDataParser
{
    static CanonicalDataParser() => ProbSpecs.Sync();
    
    internal static CanonicalData Parse(Exercise exercise) => new(exercise, ParseTestCases(exercise));

    private static JObject[] ParseTestCases(Exercise exercise)
    {
        var jsonObject = JObject.Parse(File.ReadAllText(Paths.CanonicalDataFile(exercise)));
        return ParseTestCases(jsonObject, ImmutableQueue<string>.Empty).ToArray();
    }

    private static IEnumerable<JObject> ParseTestCases(JObject jsonObject, ImmutableQueue<string> path)
    {
        var updatedPath = jsonObject.TryGetValue("description", out var description)
            ? path.Enqueue(description.Value<string>()!)
            : path;

        return jsonObject.TryGetValue("cases", out var cases)
            ? ((JArray)cases).Cast<JObject>().SelectMany(child => ParseTestCases(child, updatedPath))
            : [ToTestCase(jsonObject, updatedPath)];
    }

    private static JObject ToTestCase(JObject testCaseJson, IEnumerable<string> path)
    {
        testCaseJson["path"] = JArray.FromObject(path);
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


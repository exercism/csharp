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

internal static class CanonicalData
{
    static CanonicalData() => ProbSpecs.Sync();

    internal static TestCase[] Parse(Exercise exercise)
    {
        var json = File.ReadAllText(Paths.CanonicalDataFile(exercise));
        var jsonObject = JObject.Parse(json);
        return Parse(jsonObject, ImmutableQueue<string>.Empty)
            .ToArray();
    }

    private static IEnumerable<TestCase> Parse(JObject jsonObject, ImmutableQueue<string> path)
    {
        var updatedPath = jsonObject.TryGetValue("description", out var description)
            ? path.Enqueue(description.Value<string>()!)
            : path;

        if (jsonObject.TryGetValue("cases", out var cases))
            return ((JArray)cases).Cast<JObject>().SelectMany(child => Parse(child, updatedPath));
        
        return [ToTestCase(jsonObject, updatedPath)];
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


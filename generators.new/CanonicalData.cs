using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Generators;

internal record TestCase(
    string Uuid,
    string Description,
    string Property,
    Dictionary<string, dynamic> Input,
    dynamic Expected,
    string[] Path);

internal static class CanonicalData
{
    private static readonly JsonSerializerOptions SerializerOptions = new() { PropertyNameCaseInsensitive = true };
    
    internal static TestCase[] Parse(string canonicalDataFile) =>
        Parse(JsonNode.Parse(File.ReadAllText(canonicalDataFile))!.AsObject(), ImmutableStack<string>.Empty)
            .ToArray();

    private static IEnumerable<TestCase> Parse(JsonObject jsonObject, ImmutableStack<string> path)
    {
        var updatedPath = jsonObject.TryGetPropertyValue("description", out var description)
            ? path.Push(description!.ToString())
            : path;
        
        return jsonObject.TryGetPropertyValue("cases", out var cases)
            ? cases!.AsArray().SelectMany(child => Parse(child!.AsObject(), updatedPath))
            : [ToTestCase(jsonObject, updatedPath)];
    }

    private static TestCase ToTestCase(JsonObject jsonObject, ImmutableStack<string> path)
    {
        jsonObject["path"] = JsonValue.Create(path);
        return jsonObject.Deserialize<TestCase>(SerializerOptions)!;
    }
}
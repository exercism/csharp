using System.Text.Json;
using System.Text.Json.Nodes;

using Microsoft.CodeAnalysis.CSharp;

using Scriban;
using Scriban.Runtime;

namespace Generators;

internal static class Templates
{
    public static string RenderTestsCode(CanonicalData canonicalData)
    {
        var template = Template.Parse(File.ReadAllText(Paths.TemplateFile(canonicalData.Exercise)));
        return template.Render(TemplateData.ForCanonicalData(canonicalData));
    }

    private static class TemplateData
    {
        internal static JsonElement ForCanonicalData(CanonicalData canonicalData)
        {
            var testCases = canonicalData.TestCases.Select(Create).ToArray();
            var testCasesByProperty = GroupTestCasesByProperty(testCases);

            return JsonSerializer.SerializeToElement(new { testCases, testCasesByProperty });
        }

        private static JsonElement Create(JsonNode testCase)
        {
            testCase["testMethodName"] = Naming.ToMethodName(testCase["path"]!.AsArray().GetValues<string>().ToArray());
            testCase["shortMethodName"] = Naming.ToMethodName(testCase["description"]!.GetValue<string>());
            
            return JsonSerializer.SerializeToElement(testCase);
        }

        private static Dictionary<string, JsonElement[]> GroupTestCasesByProperty(IEnumerable<JsonElement> testCases) =>
            testCases
                .GroupBy(testCase => testCase.GetProperty("property").GetString()!)
                .ToDictionary(kv => kv.Key, kv => kv.ToArray());
    }
}
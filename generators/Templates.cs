using System.Text.Json;
using System.Text.Json.Nodes;

using Humanizer;

using Scriban;
using Scriban.Runtime;

namespace Generators;

internal static class Templates
{
    public static string RenderTestsCode(CanonicalData canonicalData)
    {
        var scriptObject = new ScriptObject();
        scriptObject.Import("enum", new Func<string, string, string>((text, enumType) => $"{enumType.Pascalize()}.{text.Pascalize()}"));;
        scriptObject.Import(TemplateData.ForCanonicalData(canonicalData));
        
        var context = new TemplateContext();
        context.PushGlobal(scriptObject);

        return Template.Parse(File.ReadAllText(Paths.TemplateFile(canonicalData.Exercise)))
            .Render(context);
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
            testCase["shortTestMethodName"] = Naming.ToMethodName(testCase["description"]!.GetValue<string>());
            
            return JsonSerializer.SerializeToElement(testCase);
        }

        private static Dictionary<string, JsonElement[]> GroupTestCasesByProperty(IEnumerable<JsonElement> testCases) =>
            testCases
                .GroupBy(testCase => testCase.GetProperty("property").GetString()!)
                .ToDictionary(kv => kv.Key, kv => kv.ToArray());
    }
}
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
        scriptObject.Import("enum", new Func<string, string, string>((text, enumType) =>
            $"{enumType.Pascalize()}.{text.Pascalize()}"));
        scriptObject.Import("property", new Func<ScriptArray, string, ScriptArray>((testCases, name) =>
            new ScriptArray(testCases.Cast<ScriptObject>().Where(testCase => testCase["property"].ToString() == name))));
        scriptObject.Import(TemplateData.ForCanonicalData(canonicalData));
        
        var context = new TemplateContext();
        context.PushGlobal(scriptObject);

        return Template.Parse(File.ReadAllText(Paths.TemplateFile(canonicalData.Exercise)))
            .Render(context);
    }

    private static class TemplateData
    {
        internal static JsonElement ForCanonicalData(CanonicalData canonicalData) =>
            JsonSerializer.SerializeToElement(new { testCases = canonicalData.TestCases.Select(Create).ToArray() });

        private static JsonElement Create(JsonNode testCase)
        {
            testCase["methodName"] = Naming.ToMethodName(testCase["path"]!.AsArray().GetValues<string>().ToArray());
            testCase["shortMethodName"] = Naming.ToMethodName(testCase["description"]!.GetValue<string>());
            
            return JsonSerializer.SerializeToElement(testCase);
        }
    }
}
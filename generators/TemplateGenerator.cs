using System.Text.Json;
using System.Text.Json.Nodes;

using Scriban;

namespace Generators;

internal static class TemplateGenerator
{
    internal static void Generate(Exercise exercise)
    {
        Console.WriteLine($"{exercise.Slug}: generating template...");
        
        var canonicalData = CanonicalDataParser.Parse(exercise);
        var filteredCanonicalData = TestCasesConfiguration.RemoveExcludedTestCases(canonicalData);

        var template = RenderTemplate(filteredCanonicalData);
        File.WriteAllText(Paths.TemplateFile(exercise), template);
    }

    private static string RenderTemplate(CanonicalData canonicalData)
    {
        var error = canonicalData.TestCases.Where(ExpectsError).Any();
        var testCase = canonicalData.TestCases.First(testCase => !ExpectsError(testCase));
        var model = new { error, assert = Assertion(testCase), throws = AssertThrows(testCase) };

        var template = Template.Parse(GeneratorTemplate);
        return template.Render(model).Trim() + Environment.NewLine;
    }

    private static string Value(string field, JsonNode? testCase) =>
        testCase is not null && testCase.GetValueKind() == JsonValueKind.String
            ? $"{{{{ {field} | string.literal }}}}"
            : $"{{{{ {field} }}}}";

    private static string Expected(JsonNode testCase) => Value("test.expected", testCase["expected"]);

    private static string Assertion(JsonNode testCase) =>
        testCase["expected"]!.GetValueKind() switch
        {
            JsonValueKind.False or JsonValueKind.True => AssertBool(testCase),
            _ => AssertEqual(testCase)
        };
    
    private static string TestedMethodArguments(JsonNode testCase) =>
        string.Join(", ", testCase["input"]!.AsObject().Select(kv => Value($"test.input.{kv.Key}", kv.Value!)));

    private static string TestedMethodCall(JsonNode testCase) =>
        $"{{{{ testedClass }}}}.{{{{ test.testedMethod }}}}({TestedMethodArguments(testCase)})";

    private static string AssertBool(JsonNode testCase) =>
        $"Assert.{{{{ test.expected ? \"True\" : \"False\" }}}}({TestedMethodCall(testCase)});";
    
    private static string AssertEqual(JsonNode testCase) =>
        $"Assert.Equal({Expected(testCase)}, {TestedMethodCall(testCase)});";
    
    private static string AssertThrows(JsonNode testCase) =>
        $"Assert.Throws<ArgumentException>(() => {TestedMethodCall(testCase)});";

    private static bool ExpectsError(this JsonNode testCase) =>
        testCase["expected"] is JsonObject jsonObject && jsonObject.ContainsKey("error");

    private const string GeneratorTemplate = @"
{{ if error }}using System;{{ end }}
using Xunit;

public class {%{{{ testClass }}}%}
{
    {%{{{- for test in tests }}}%}
    [Fact{%{{{ if !for.first }}}%}(Skip = ""Remove this Skip property to run this test""){%{{{ end }}}%}]
    public void {%{{{ test.testMethod }}}%}()
    {
        {{- if error }}
        {%{{{- if test.expected.error }}}%}
            {{ throws }}
        {%{{{ else }}}%}
            {{ assert }}
        {%{{{ end -}}}%}
        {{- else }}
        {{ assert }}
        {{- end }}
    }
    {%{{{end -}}}%}
}";
}
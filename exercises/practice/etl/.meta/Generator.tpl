public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        var legacy = new Dictionary<int, string[]>
        {
            {{- for key in test.input.legacy | object.keys }}
            [{{ key }}] = {{ test.input.legacy[key] }}{{- if !for.last }},{{ end -}}
            {{ end -}}
        };
        var expected = new Dictionary<string, int>
        {
            {{- for key in test.expected | object.keys }}
            [{{ key | string.literal }}] = {{ test.expected[key] }}{{- if !for.last }},{{ end -}}
            {{ end -}}
        };
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(legacy));
    }
    {{ end -}}
}

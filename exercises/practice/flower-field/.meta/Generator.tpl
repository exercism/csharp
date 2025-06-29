public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.input.garden.empty? }}
        Assert.Empty({{ testedClass }}.{{ test.testedMethod }}(Array.Empty<string>()));
        {{ else }}
        string[] garden = [
        {{- for line in test.input.garden }}
            {{ line | string.literal }}{{- if !for.last }},{{ end -}}
        {{ end }}
        ];
        string[] expected = [
        {{- for line in test.expected }}
            {{ line | string.literal }}{{- if !for.last }},{{ end -}}
        {{ end }}
        ];
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(garden));
        {{ end -}}
    }
    {{ end -}}
}

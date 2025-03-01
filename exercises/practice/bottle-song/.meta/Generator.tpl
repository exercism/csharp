public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        string[] expected = [
        {{- for line in test.expected }}
            {{ line | string.literal }}{{- if !for.last }},{{ end -}}
        {{ end }}
        ];
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.startBottles }}, {{ test.input.takeDown }}));
    }
    {{ end -}}
}

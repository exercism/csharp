using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.expected | array.size > 1 }}
        int[][] expected = [
        {{- for row in test.expected }}
            {{ row }}{{- if !for.last }},{{ end -}}
        {{ end }}
        ];
        {{- else }}
        int[][] expected = {{ test.expected }};
        {{ end -}}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.cage.sum }}, {{ test.input.cage.size }}, {{ test.input.cage.exclude }}));
    }
    {{ end -}}
}

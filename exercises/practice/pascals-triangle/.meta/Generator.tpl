using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.expected.empty? }}
        Assert.Empty({{ testedClass }}.Calculate({{ test.input.count }}));
        {{ else }}
        int[][] expected = [
        {{- for row in test.expected }}
            {{ row }}{{- if !for.last }},{{ end -}}
        {{ end }}
        ];
        Assert.Equal(expected, {{ testedClass }}.Calculate({{ test.input.count }}));
        {{ end -}}
    }
    {{ end -}}
}

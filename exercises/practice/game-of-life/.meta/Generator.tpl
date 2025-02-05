using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        int[,] matrix =
        {
        {{- for row in test.input.matrix }}
            { {{ row | array.join ", " }} }{{- if !for.last }},{{ end -}}
        {{ end }}
        };
        {{- if test.expected.empty? }}
        Assert.Empty({{ testedClass }}.{{ test.testedMethod }}(matrix));
        {{ else }}
        int[,] expected =
        {
        {{- for row in test.expected }}
            { {{ row | array.join ", " }} }{{- if !for.last }},{{ end -}}
        {{ end }}
        };
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(matrix));
        {{ end -}}
    }
    {{ end -}}
}

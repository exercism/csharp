using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.expected.empty? }}
        Assert.Empty({{ testedClass }}.GetMatrix({{ test.input.size }}));
        {{ else }}
        int[,] expected = new[,]
        {
        {{- for row in test.expected }}
            { {{ row | array.join ", " }} }{{- if !for.last }},{{ end -}}
        {{ end }}
        };
        Assert.Equal(expected, {{ testedClass }}.GetMatrix({{ test.input.size }}));
        {{ end -}}
    }
    {{ end -}}
}

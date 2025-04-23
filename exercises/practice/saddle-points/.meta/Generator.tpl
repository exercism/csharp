public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        int[,] matrix =
        {
        {{- for row in test.input.matrix }}
            {{- if !row.empty? }}
            { {{ row | array.join ", " }} }{{- if !for.last }},{{ end -}}
            {{ end -}}
        {{ end }}
        };
        {{- if test.expected.empty? }}
        Assert.Empty({{ testedClass }}.Calculate(matrix));
        {{ else }}
        HashSet<(int, int)> expected = [{{ for pair in test.expected }}({{ pair.row }}, {{ pair.column }}){{ if !for.last}}, {{ end }}{{ end }}];
        Assert.Equal(expected, {{ testedClass }}.Calculate(matrix).ToHashSet());
        {{ end -}}
    }
    {{ end -}}
}

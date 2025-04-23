public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.expected.empty? }}
        Assert.Empty({{ testedClass }}.{{ test.testedMethod }}({{ test.input.n }}));
        {{- else }}
        (int,int,int)[] expected = [
        {{- for expected in test.expected }}
            ({{ expected | array.join ", " }}){{- if !for.last }},{{ end -}}
        {{ end }}
        ];
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.n }}));
        {{ end -}}
    }
    {{ end -}}
}

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.expected.empty? }}
        Assert.Empty({{ testedClass }}.{{ test.testedMethod }}({{ test.input.strand | string.literal }}));
        {{ else }}
        string[] expected = {{ test.expected }};
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.strand | string.literal }}));
        {{ end -}}
    }
    {{ end -}}
}

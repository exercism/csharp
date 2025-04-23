public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        string[] expected = {{ test.expected }};
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.tonic | string.literal }}{{ if test.input.intervals }}, {{ test.input.intervals | string.literal}} {{ end }}));
    }
    {{ end -}}
}

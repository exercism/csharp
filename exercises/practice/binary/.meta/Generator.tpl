public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        Assert.Equal({{ if test.expected }}{{ test.expected }}{{ else }}0{{ end }}, {{ testedClass }}.To{{ test.testedMethod }}({{ test.input.binary | string.literal }}));
    }
    {{ end -}}
}

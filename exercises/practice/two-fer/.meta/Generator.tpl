public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        Assert.Equal({{ test.expected | string.literal }}, {{ testedClass }}.Speak({{ if !test.input.name.empty? }}{{ test.input.name | string.literal }}{{ end }}));
    }
    {{ end -}}
}

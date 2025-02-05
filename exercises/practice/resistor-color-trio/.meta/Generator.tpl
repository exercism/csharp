using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        Assert.Equal("{{ test.expected.value }} {{ test.expected.unit }}", {{ testedClass }}.{{ test.testedMethod }}({{ test.input.colors }}));
    }
    {{ end -}}
}

using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.shortTestMethod }}()
    {
        Assert.Equal({{ test.expected | string.literal }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.phrase | string.literal }}));
    }
    {{ end -}}
}

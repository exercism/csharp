using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        string[] hands = {{ test.input.hands }};
        string[] expected = {{ test.expected }};
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(hands));
    }
    {{ end -}}
}

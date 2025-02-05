using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        string[] candidates = {{ test.input.candidates }};
        var sut = new {{ testedClass }}({{ test.input.subject | string.literal }});
        {{- if test.expected.empty? }}
        Assert.Empty(sut.FindAnagrams(candidates));
        {{ else }}
        string[] expected = {{ test.expected }};
        Assert.Equal(expected, sut.FindAnagrams(candidates));
        {{ end -}}
    }
    {{ end -}}
}

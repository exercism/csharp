using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.shortTestMethod }}()
    {
        var msg = {{ test.input.msg | string.literal }};
        var sut = new RailFenceCipher({{ test.input.rails }});
        var expected = {{ test.expected | string.literal }};
        Assert.Equal(expected, sut.{{ test.testedMethod }}(msg));
    }
    {{ end -}}
}

using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact]
    public void {{ test.testMethod }}()
    {
        var markdown = {{ test.input.markdown | string.literal }};
        var expected = {{ test.expected | string.literal }};
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(markdown));
    }
    {{ end -}}
}

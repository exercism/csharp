using System;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.expected.error }}
        Assert.Throws<ArgumentException>(() => Hamming.Distance({{ test.input.strand1 | string.literal }}, {{ test.input.strand2 | string.literal }}));
        {{ else }}
        Assert.Equal({{ test.expected }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.strand1 | string.literal }}, {{ test.input.strand2 | string.literal }}));
        {{ end -}}
    }
    {{ end -}}
}

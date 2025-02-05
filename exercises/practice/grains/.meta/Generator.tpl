using System;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.shortTestMethod }}()
    {
        {{- if test.expected.error }}
            Assert.Throws<ArgumentOutOfRangeException>(() => {{ testedClass }}.{{ test.testedMethod }}({{ test.input.square }}));
        {{ else }}
            Assert.Equal({{ test.expected }}UL, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.square }}));
        {{ end -}}
    }
    {{ end -}}
}

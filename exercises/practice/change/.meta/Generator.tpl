using System;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.expected.error }}
            int[] coins = {{ test.input.coins }};
            Assert.Throws<ArgumentException>(() => {{ testedClass }}.{{ test.testedMethod }}(coins, {{ test.input.target }}));
        {{ else }}
            int[] coins = {{ test.input.coins }};
            int[] expected = {{ test.expected }};
            Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(coins, {{ test.input.target }}));
        {{ end -}}
    }
    {{ end -}}
}

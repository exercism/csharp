using System;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.expected.error || test.expected.value == null }}
            Assert.Throws<ArgumentException>(() => {{ testedClass }}.{{ test.testedMethod }}({{ test.input.min }}, {{ test.input.max }}));
        {{ else }}
            var (value, factors) = {{ testedClass }}.{{ test.testedMethod }}({{ test.input.min }}, {{ test.input.max }});
            int expectedValue = {{ test.expected.value }};
            (int, int)[] expectedFactors = [{{ for factor in test.expected.factors }}({{ factor | array.join ", "}}){{ if !for.last }}, {{ end }}{{ end }}];
            Assert.Equal(expectedValue, value);
            Assert.Equal(expectedFactors, factors);
        {{ end -}}
    }
    {{ end -}}
}

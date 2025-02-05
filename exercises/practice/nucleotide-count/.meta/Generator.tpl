using System;
using System.Collections.Generic;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.expected.error }}
            Assert.Throws<ArgumentException>(() => {{ testedClass }}.Count({{ test.input.strand | string.literal }}));
        {{ else }}
            var expected = new Dictionary<char, int>
            {
                {{- for key in test.expected | object.keys }}
                ['{{ key }}'] = {{ test.expected[key] }}{{- if !for.last }},{{ end -}}
                {{ end -}}
            };
            Assert.Equal(expected, {{ testedClass }}.Count({{ test.input.strand | string.literal }}));
        {{ end -}}
    }
    {{ end -}}
}

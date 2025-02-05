using System.Collections.Generic;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.input.texts.empty? }}
        string[] texts = [];
        {{- else }}
        string[] texts = [
        {{- for text in test.input.texts }}
            {{ text | string.literal }}{{- if !for.last }},{{ end -}}
        {{ end }}
        ];
        {{ end -}}
        var expected = new Dictionary<char, int>
        {
            {{- for key in test.expected | object.keys }}
            ['{{ key }}'] = {{ test.expected[key] }}{{- if !for.last }},{{ end -}}
            {{ end -}}
        };
        Assert.Equal(expected, {{ testedClass }}.Calculate(texts));
    }
    {{ end -}}
}

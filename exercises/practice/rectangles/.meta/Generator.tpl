using System;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod | string.replace "1x1" "One_by_one" }}()
    {
        {{- if test.input.strings.empty? }}
        string[] rows = Array.Empty<string>();
        {{ else }}
        string[] rows = [
        {{- for row in test.input.strings }}
            {{ row | string.literal }}{{- if !for.last }},{{ end -}}
        {{ end }}
        ];
        {{ end -}}
        Assert.Equal({{ test.expected }}, {{ testedClass }}.Count(rows));
    }
    {{ end -}}
}

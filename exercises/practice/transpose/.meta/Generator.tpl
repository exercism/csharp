{{ func lines(lines, variable) }}
    {{- if test.input.lines.empty? }}
    var {{variable}} = "";
    {{- else }}
    var {{variable}} =
    {{- for line in lines }}
        {{ if for.last -}}
        {{ line | string.literal -}};
        {{- else -}}
        {{ line | string.append "\n" | string.literal }} +
        {{- end -}}
    {{- end }}
    {{- end -}}
{{ end }}

using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- test.input.lines | lines "lines" }}
        {{- test.expected | lines "expected" }}
        Assert.Equal(expected, {{ testedClass }}.String(lines));
    }
    {{ end -}}
}

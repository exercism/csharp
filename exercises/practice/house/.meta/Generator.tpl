using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        var expected =
        {{- for line in test.expected }}
            {{- if for.last -}}
            {{ line | string.literal }};
            {{- else -}}
            {{ line | string.append "\n" | string.literal }} +
            {{ end -}}
        {{- end }}
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.startVerse }}{{if test.input.endVerse != test.input.startVerse }}, {{ test.input.endVerse }}{{ end }}));
    }
    {{ end -}}
}

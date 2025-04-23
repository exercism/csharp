public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        var rows =
        {{- for line in test.input.rows }}
            {{ if for.last -}}
            {{ line | string.literal -}};
            {{- else -}}
            {{ line | string.append "\n" | string.literal }} +
            {{- end -}}
        {{- end }}
        {{- if test.expected.error }}
            Assert.Throws<ArgumentException>(() => {{ testedClass }}.{{ test.testedMethod }}(rows));
        {{ else }}
            Assert.Equal({{ test.expected | string.literal }}, {{ testedClass }}.{{ test.testedMethod }}(rows));
        {{ end -}}
    }
    {{ end -}}
}

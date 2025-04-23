public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact]
    public void {{ test.testMethod }}()
    {
        var currency = {{ test.input.currency | string.literal }};
        var locale = {{ test.input.locale | string.replace "_" "-" | string.literal }};
        {{- if test.input.entries.empty? }}
        LedgerEntry[] entries = [];
        {{ else }}
        LedgerEntry[] entries = [
            {{- for entry in test.input.entries }}
            {{ testedClass }}.CreateEntry({{ entry.date | string.literal }}, {{ entry.description | string.literal }}, {{ entry.amountInCents }}){{- if !for.last }},{{ end -}}
            {{ end }}
        ];
        {{ end -}}
        var expected =
        {{- for line in test.expected }}
            {{ if for.last -}}
            {{ line | string.literal -}};
            {{- else -}}
            {{ line | string.append "\n" | string.literal }} +
            {{- end -}}
        {{- end }}
        Assert.Equal(expected, {{ testedClass }}.Format(currency, locale, entries));
    }
    {{ end -}}
}

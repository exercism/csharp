{{ func tuple
    ret $"({$0.column}, {$0.row})"
end }}
public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        string[] wordsToSearchFor = {{ test.input.wordsToSearchFor }};
        var grid =
        {{- for line in test.input.grid }}
            {{ if for.last -}}
            {{ line | string.literal -}};
            {{- else -}}
            {{ line | string.append "\n" | string.literal }} +
            {{- end -}}
        {{- end }}
        var sut = new {{ testedClass }}(grid);
        var actual = sut.Search(wordsToSearchFor);
        {{- for key in test.expected | object.keys }}
            {{- if test.expected[key] }}
            Assert.Equal(({{ test.expected[key].start | tuple }}, {{ test.expected[key].end | tuple }}), actual[{{ key | string.literal }}]);
            {{- else }}
            Assert.Null(actual[{{ key | string.literal }}]);
            {{ end -}}
        {{ end -}}
    }
    {{ end -}}
}

public class DequeTests
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        var sut = new Deque<int>();
        {{- for op in test.input.operations }}
        {{- if op.operation != "count" }}
        {{- if op.expected }}
        Assert.Equal({{ op.expected }}, sut.{{ op.operation | string.capitalize }}());
        {{- else }}
        sut.{{ op.operation | string.capitalize }}({{ op.value }});
        {{- end -}}
        {{- end -}}
        {{ end -}}
    }
    {{ end -}}
}

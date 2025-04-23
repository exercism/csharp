public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        var buffer = new {{ testedClass }}<int>(capacity: {{ test.input.capacity }});
        {{- for operation in test.input.operations }}
        {{- if operation.should_succeed != false }}
        {{- if operation.operation == "read" }}
        Assert.Equal({{ operation.expected }}, buffer.{{ operation.operation | string.capitalize }}());
        {{- else }}
        buffer.{{ operation.operation | string.capitalize }}({{ operation.item }});
        {{- end -}}
        {{- else }}
        Assert.Throws<InvalidOperationException>(() => buffer.{{ operation.operation | string.capitalize }}({{ operation.item }}));
        {{ end -}}
        {{ end -}}
    }
    {{ end -}}
}

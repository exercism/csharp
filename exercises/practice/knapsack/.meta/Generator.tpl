public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        (int weight, int value)[] items = [{{for item in test.input.items}}(weight: {{item.weight}}, value: {{item.value}}){{if !for.last}}, {{end}}{{end}}];
        Assert.Equal({{ test.expected }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.maximumWeight }}, items));
    }
    {{ end -}}
}

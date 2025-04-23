{{ func clock 
    $"new Clock({$0.hour}, {$0.minute})"
end }}

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.shortTestMethod }}()
    {
        {{- if test.property == "equal" }}
        Assert.{{ test.expected ? "Equal" : "NotEqual" }}({{ test.input.clock1 | clock }}, {{ test.input.clock2 | clock }});
        {{- else if test.property == "create" }}
        Assert.Equal({{ test.expected | string.literal }}, {{ test.input | clock }}.ToString());
        {{- else }}
        Assert.Equal({{ test.expected | string.literal }}, {{ test.input | clock }}.{{ test.testedMethod }}({{ test.input.value }}).ToString());        
        {{ end -}}
    }
    {{ end -}}
}

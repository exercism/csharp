public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.property == "consistency" }}
        Assert.Equal({{ test.expected | string.literal }}, {{ testedClass }}.Decode({{ testedClass }}.Encode({{ test.input.string | string.literal }})));
        {{ else }}
        Assert.Equal({{ test.expected | string.literal }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.string | string.literal }}));
        {{ end -}}
    }
    {{ end -}}
}

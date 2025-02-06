{{ func toset 
    $"new CustomSet({$0})"
end }}
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        var sut = {{ test.input.set | toset }};
        {{- if test.property == "empty" }}
        Assert.{{ test.expected ? "True" : "False" }}(sut.{{ test.testedMethod }}());
        {{- else if test.property == "contains" }}
        Assert.{{ test.expected ? "True" : "False" }}(sut.{{ test.testedMethod }}({{ test.input.element }}));
        {{- else if test.property == "add" }}
        var expected = {{ test.expected | toset }};
        Assert.Equal(expected, sut.{{ test.testedMethod }}({{ test.input.element }}));
        {{- else }}
        var set1 = {{ test.input.set1 | toset }};
        var set2 = {{ test.input.set2 | toset }};
        {{- if test.property == "equal" }}
        Assert.{{ test.expected ? "Equal" : "NotEqual" }}(set1, set2);
        {{- else if test.expected | object.typeof == "array"}}
        var expected = {{ test.expected | toset }};
        Assert.Equal(expected, set1.{{ test.testedMethod }}(set2));
        {{- else }}
        Assert.{{ test.expected ? "True" : "False" }}(set1.{{ test.testedMethod }}(set2));
        {{ end -}}
        {{ end -}}
    }
    {{ end -}}
}

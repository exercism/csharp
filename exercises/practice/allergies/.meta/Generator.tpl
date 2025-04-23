public class {{ testClass }}
{
    {{- for test in tests | property "allergicTo" }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        var sut = new {{ testedClass }}({{ test.input.score }});
        Assert.{{ test.expected ? "True" : "False" }}(sut.IsAllergicTo({{ test.input.item | enum "Allergen" }}));
    }
    {{ end }}

    {{- for test in tests | property "list"}}
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void {{ test.testMethod }}()
    {
        var sut = new {{ testedClass }}({{ test.input.score }});
        {{- if test.expected.empty? }}
        Assert.Empty(sut.List());
        {{ else }}
        Allergen[] expected = [
        {{- for expected in test.expected }}
            {{ expected | enum "Allergen" }}{{- if !for.last }},{{ end -}}
        {{ end }}
        ];
        Assert.Equal(expected, sut.List());
        {{ end -}}
    }
    {{ end }}
}

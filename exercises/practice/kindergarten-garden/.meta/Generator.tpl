public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        var sut = new {{ testedClass }}({{ test.input.diagram | string.literal }});
        Plant[] expected = [
        {{- for expected in test.expected -}}
            {{ expected | enum "Plant" }}{{- if !for.last }},{{ end -}}
        {{- end -}}
        ];
        Assert.Equal(expected, sut.{{ test.testedMethod }}({{ test.input.student | string.literal }}));
    }
    {{ end -}}
}

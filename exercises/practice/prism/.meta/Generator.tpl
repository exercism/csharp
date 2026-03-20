public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        Prism.LaserInfo laser = new({{ test.input.start.x }}, {{ test.input.start.y }}, {{ test.input.start.angle }});
        {{- if test.input.prisms.empty? }}
        Prism.PrismInfo[] prisms = [];
        {{- else }}
        Prism.PrismInfo[] prisms =
        [
            {{- for p in test.input.prisms }}
            new({{ p.id }}, {{ p.x }}, {{ p.y }}, {{ p.angle }}){{ if !for.last }},{{ end }}
            {{- end }}
        ];
        {{- end }}
        int[] expected = [{{ array.join test.expected.sequence ", " }}];
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(laser, prisms));
    }
    {{ end -}}
}

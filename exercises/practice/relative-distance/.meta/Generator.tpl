public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        Dictionary<string, string[]> familyTree = new()
        {
            {{- for entry in test.input.familyTree }}
            { "{{ entry.key }}", [{{ for name in entry.value }}"{{ name }}"{{ if !for.last }}, {{ end }}{{ end }}] }{{ if !for.last }},{{ end }}
            {{- end }}
        };
        RelativeDistance rd = new(familyTree);
        Assert.Equal({{ if test.expected }}{{ test.expected }}{{ else }}{{ -1 }}{{ end }}, rd.DegreeOfSeparation({{ test.input.personA | string.literal }}, {{ test.input.personB | string.literal }}));
    }
    {{ end -}}
}

{{ func toarg
    if (object.typeof $0) == "array"
        ret "new List<int> {" + (array.join $0 ", ") + "}"
    else
        ret $0
    end
end }}

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.shortTestMethod }}()
    {
        var sut = new {{ testedClass }}({{ test.input.scores | toarg }});
        {{- if test.property == "latestAfterTopThree" || test.property == "scoresAfterTopThree" }}
        var _ = sut.PersonalTopThree();
        Assert.Equal({{ test.expected | toarg }}, sut.{{ test.testedMethod | string.replace "AfterTopThree" "" | string.capitalize }}());
        {{- else if test.property == "latestAfterBest" || test.property == "scoresAfterBest" }}
        var _ = sut.PersonalBest();
        Assert.Equal({{ test.expected | toarg }}, sut.{{ test.testedMethod | string.replace "AfterBest" "" | string.capitalize }}());
        {{- else }}
        Assert.Equal({{ test.expected | toarg }}, sut.{{ test.testedMethod }}());
        {{- end }}        
    }
    {{ end -}}
}

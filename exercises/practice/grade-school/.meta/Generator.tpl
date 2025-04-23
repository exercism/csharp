public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        var sut = new GradeSchool();
        {{- if test.property == "add" }}
        {{ for i in 0..((array.size test.input.students) - 1) -}}
        Assert.{{ test.expected[i] ? "True" : "False" }}(sut.Add({{test.input.students[i][0] | string.literal }}, {{test.input.students[i][1]}}));
        {{ end -}}
        {{- else }}
        {{ for student in test.input.students -}}
        sut.Add({{ student[0] | string.literal }}, {{ student[1] }});
        {{ end -}}
        string[] expected = {{ test.expected }};
        Assert.Equal(expected, sut.{{ test.testedMethod }}({{ test.input.desiredGrade }}));
        {{ end -}}
    }
    {{ end -}}
}

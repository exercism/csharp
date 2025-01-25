using Xunit;

public class {{exercise.name}}Tests
{
    {{for test_case in test_cases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test_case.path | method_name}}()
    {
        Assert.Equal("{{test_case.expected}}", Acronym.Abbreviate("{{test_case.input.phrase}}"));
    }
    {{end}}
}

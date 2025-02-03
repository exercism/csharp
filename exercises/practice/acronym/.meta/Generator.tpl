using Xunit;

public class AcronymTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        Assert.Equal({{test.expected | string.literal}}, Acronym.Abbreviate({{test.input.phrase | string.literal}}));
    }
    {{end}}
}

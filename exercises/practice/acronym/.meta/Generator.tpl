using Xunit;

public class AcronymTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        Assert.Equal({{testCase.expected | string.literal}}, Acronym.Abbreviate({{testCase.input.phrase | string.literal}}));
    }
    {{end}}
}

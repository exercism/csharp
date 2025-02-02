using Xunit;

public class IsogramTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.testMethodName}}()
    {
        Assert.{{testCase.expected ? "True" : "False"}}(Isogram.IsIsogram({{testCase.input.phrase | string.literal}}));
    }
    {{end}}
}

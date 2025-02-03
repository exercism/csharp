using Xunit;

public class PangramTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        Assert.{{testCase.expected ? "True" : "False"}}(Pangram.IsPangram({{testCase.input.sentence | string.literal}}));
    }
    {{end}}
}

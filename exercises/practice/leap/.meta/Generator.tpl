using Xunit;

public class LeapTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        Assert.{{testCase.expected ? "True" : "False"}}(Leap.IsLeapYear({{testCase.input.year}}));
    }
    {{end}}
}

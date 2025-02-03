using Xunit;

public class ZebraPuzzleTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        Assert.Equal(Nationality.{{testCase.expected}}, {{testCase.property | enum "ZebraPuzzle"}}());
    }
    {{end}}
}

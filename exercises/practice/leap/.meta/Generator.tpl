using Xunit;

public class LeapTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        Assert.{{test.expected ? "True" : "False"}}(Leap.IsLeapYear({{test.input.year}}));
    }
    {{end}}
}

using Xunit;

public class ArmstrongNumbersTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        Assert.{{test.expected ? "True" : "False"}}(ArmstrongNumbers.IsArmstrongNumber({{test.input.number}}));
    }
    {{end}}
}

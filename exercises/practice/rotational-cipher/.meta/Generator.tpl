using Xunit;

public class RotationalCipherTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        Assert.Equal({{testCase.expected | string.literal}}, RotationalCipher.Rotate({{testCase.input.text | string.literal}}, {{testCase.input.shiftKey}}));
    }
    {{end}}
}

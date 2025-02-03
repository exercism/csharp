using Xunit;

public class TwoFerTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        Assert.Equal({{testCase.expected | string.literal}}, TwoFer.Speak({{if !testCase.input.name.empty?}}{{testCase.input.name | string.literal}}{{end}}));
    }
    {{end}}
}

using Xunit;

public class TwoFerTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        Assert.Equal({{test.expected | string.literal}}, TwoFer.Speak({{if !test.input.name.empty?}}{{test.input.name | string.literal}}{{end}}));
    }
    {{end}}
}

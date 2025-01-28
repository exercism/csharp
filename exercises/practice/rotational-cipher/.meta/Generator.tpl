using Xunit;

public class RotationalCipherTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        Assert.Equal({{expected}}, RotationalCipher.Rotate({{lit input.text}}, {{input.shiftKey}}));
    }
    {{/test_cases}}
}

using Xunit;

public class {{exercise.name}}Tests
{
    {{for test_case in test_cases_by_property.squareOfSum}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test_case.path | array.last | method_name}}()
    {
        Assert.Equal({{test_case.expected}}, {{exercise.name}}.CalculateSquareOfSum({{test_case.input.number}}));
    }
    {{end}}    
}

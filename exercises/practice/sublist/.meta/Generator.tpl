using System.Collections.Generic;
using Xunit;

public class {{testClass}}
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.testMethod}}()
    {
        List<int> listOne = {{test.input.listOne}};
        List<int> listTwo = {{test.input.listTwo}};
        Assert.Equal({{test.expected | enum "SublistType"}}, {{testedClass}}.Classify(listOne, listTwo));
    }
    {{end}}
}

using System.Collections.Generic;
using Xunit;

public class SublistTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        List<int> listOne = {{testCase.input.listOne}};
        List<int> listTwo = {{testCase.input.listTwo}};
        Assert.Equal({{testCase.expected | enum "SublistType"}}, Sublist.Classify(listOne, listTwo));
    }
    {{end}}
}

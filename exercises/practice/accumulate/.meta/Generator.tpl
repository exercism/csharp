{{ func normalize 
    normalized = string.replace $0 "upcase(x)" "x.ToUpper()"
    normalized = string.replace normalized "reverse(x)" "new string(x.Reverse().ToArray())"
    string.replace normalized "accumulate([\"1\", \"2\", \"3\"], " "new[] { \"1\", \"2\", \"3\" }.Accumulate("
end }}

{{ func vartype 
    case (object.typeof (array.first $0))
        when "string"
            ret "string[]"
        when "array"
            ret "string[][]"
        else
            ret "int[]"
    end
end }}
using System.Linq;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{ test.input.list | vartype }} input = {{ test.input.list }};
        {{ test.expected | vartype }} expected = {{ test.expected }};
        Assert.Equal(expected, input.{{ test.testedMethod }}({{ test.input.accumulator | normalize }}));
    }
    {{ end }}
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Accumulate_is_lazy()
    {
        var counter = 0;
        int[] input = [1, 2, 3];
        var accumulation = input.Accumulate(x => x * counter++);
        Assert.Equal(0, counter);
        var _ = accumulation.ToList();
        Assert.Equal(3, counter);
    }
}

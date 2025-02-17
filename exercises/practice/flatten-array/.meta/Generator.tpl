{{ func toarg(input)
    case (object.typeof input)
        when "array"
            if input.empty?
                ret "Array.Empty<object?>()"
            else
                elements = array.join (array.each input @toarg) ", "
                ret "new object?[] { " + elements + " }"
            end
        else
            if input
                ret input
            else
                ret "null"
            end
        end
end }}

using System;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.input.array.empty? }}
        var array = Array.Empty<object?>();
        Assert.Empty({{ testedClass }}.{{ test.testedMethod }}(array));
        {{- else }}
        object?[] array = {{ test.input.array | toarg }};
        object?[] expected = {{ test.expected }};
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(array));
        {{ end -}}
    }
    {{ end -}}
}

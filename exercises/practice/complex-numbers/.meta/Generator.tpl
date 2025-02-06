{{ func toarg 
    case (object.typeof $0)
        when "array"
            ret $"new ComplexNumber({toarg $0[0]}, {toarg $0[1]})"
        when "string"
            str = string.replace $0 "ln(2)" "Math.Log(2.0)"
            str = string.replace str "pi" "Math.PI"
            str = string.replace str "e" "Math.E"
            ret str
        else
            ret $0
    end
end }}

using System;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.shortTestMethod }}()
    {
        {{- if test.input.z1 }}
        var actual = {{ test.input.z1 | toarg }}.{{ test.testedMethod }}({{ test.input.z2 | toarg }});
        Assert.Equal({{ test.expected[0] | toarg }}, actual.Real());
        Assert.Equal({{ test.expected[1] | toarg }}, actual.Imaginary());
        {{- else if test.input.z }}
        {{- if test.expected | object.typeof == "number" }}
        Assert.Equal({{ test.expected | toarg }}, {{ test.input.z | toarg }}.{{ test.testedMethod }}());
        {{- else }}
        var actual = {{ test.input.z | toarg }}.{{ test.testedMethod }}();
        Assert.Equal({{ test.expected[0] | toarg }}, actual.Real(){{ if test.property == "exp" }}, precision: 7{{ end }});
        Assert.Equal({{ test.expected[1] | toarg }}, actual.Imaginary(){{ if test.property == "exp" }}, precision: 7{{ end }});
        {{ end -}}
        {{ end -}}
    }
    {{ end -}}
}

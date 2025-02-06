{{ func operand 
    case $0
        when "add"
            ret "+"
        when "sub"
            ret "-"
        when "mul"
            ret "*"
        when "div"
            ret "/"
    end
end }}

{{ func toarg 
    case (object.typeof $0)
        when "array"
            ret $"new RationalNumber({toarg $0[0]}, {toarg $0[1]})"
        else
            ret $0
    end
end }}

using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.shortTestMethod }}()
    {
        {{- if test.input.r1 }}
        Assert.Equal({{ test.expected | toarg }}, {{ test.input.r1 | toarg }} {{ test.property | operand }} {{ test.input.r2 | toarg }});
        {{- else if test.input.x }}
        Assert.Equal({{ test.expected | toarg }}, {{ test.input.x | toarg }}.{{ test.testedMethod }}({{ test.input.r | toarg }}), precision: 7);
        {{- else if test.input.r }}
        Assert.Equal({{ test.expected | toarg }}, {{ test.input.r | toarg }}.{{ test.testedMethod }}({{ test.input.n | toarg }}));
        {{ end -}}
    }
    {{ end -}}
}

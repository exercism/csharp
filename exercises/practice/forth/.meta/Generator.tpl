using System;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.expected.error }}
            Assert.Throws<{{ if test.expected.error == "divide by zero" }}DivideByZeroException{{ else }}InvalidOperationException{{ end }}>(() => {{ testedClass }}.{{ test.testedMethod }}({{ test.input.instructions }}));
        {{ else if test.property == "evaluateBoth" }}
            Assert.Equal("{{test.expected[0] | array.join " "}}", {{ testedClass }}.Evaluate({{ test.input.instructionsFirst }}));
            Assert.Equal("{{test.expected[1] | array.join " "}}", {{ testedClass }}.Evaluate({{ test.input.instructionsSecond }}));
        {{ else }}
            Assert.Equal("{{test.expected | array.join " "}}", {{ testedClass }}.{{ test.testedMethod }}({{ test.input.instructions }}));
        {{ end -}}
    }
    {{ end -}}
}

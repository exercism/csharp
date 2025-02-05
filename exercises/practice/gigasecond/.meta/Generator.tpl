{{func datetime
    d = date.parse $0
    if d.hour + d.minute + d.second == 0
        $"new DateTime({d.year}, {d.month}, {d.day})"
    else
        $"new DateTime({d.year}, {d.month}, {d.day}, {d.hour}, {d.minute}, {d.second})"
    end
end}}

using System;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        Assert.Equal({{test.expected | datetime}}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.moment | datetime }}));
    }
    {{ end -}}
}

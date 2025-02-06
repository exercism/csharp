{{ func sut 
    $"new RobotSimulator({enum $0.direction "Direction"}, {$0.position.x}, {$0.position.y})"
end }}

using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        var sut = {{ test.input | sut }};
        {{- if test.property == "move" }}
        sut.Move({{ test.input.instructions | string.literal }});        
        {{- end }}
        Assert.Equal({{ test.expected.direction | enum "Direction" }}, sut.Direction);
        Assert.Equal({{ test.expected.position.x }}, sut.X);
        Assert.Equal({{ test.expected.position.y }}, sut.Y);
    }
    {{ end -}}
}

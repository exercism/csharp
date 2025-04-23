public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        var sut = new Meetup({{ test.input.month }}, {{ test.input.year }});
        var expected = new DateTime({{test.expected | string.replace "-0" "-" | string.replace "-" ", "}});
        Assert.Equal(expected, sut.Day({{ test.input.dayofweek | enum "DayOfWeek" }}, {{ test.input.week | enum "Schedule" }}));
    }
    {{ end -}}
}

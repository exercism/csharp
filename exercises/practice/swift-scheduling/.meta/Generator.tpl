{{func to_datetime
    d = date.parse $0
    if d.hour + d.minute + d.second == 0
        $"new DateTime({d.year}, {d.month}, {d.day})"
    else
        $"new DateTime({d.year}, {d.month}, {d.day}, {d.hour}, {d.minute}, {d.second})"
    end
end}}

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod | string.replace "4_m" "Four_m" | string.replace "2_m" "Two_m" | string.replace "11_m" "Eleven_m" }}()
    {
        var meetingStart = {{ test.input.meetingStart | to_datetime }};
        var expected = {{ test.expected | to_datetime }};
        Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(meetingStart, {{ test.input.description | string.literal }}), TimeSpan.FromSeconds(1));
    }
    {{ end -}}
}

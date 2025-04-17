{{ func to_timespan
    if $0 == "00:00:00"
        ret "TimeSpan.Zero"
    end

    parts = string.split $0 ":"
    hours = parts[0] | string.to_int
    minutes = parts[1] | string.to_int
    seconds = parts[2] | string.to_int        
    $"new TimeSpan({hours},{minutes},{seconds})"
end }}

using Microsoft.Extensions.Time.Testing;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- for command in test.input.commands }}
        {{- if command.command == "new" }}
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new {{ testedClass }}(timeProvider);
        {{- else if command.command == "state" }}
        Assert.Equal({{ command.expected | enum "StopwatchState" }}, stopwatch.State);
        {{- else if command.command == "currentLap" }}
        Assert.Equal({{ command.expected | to_timespan }}, stopwatch.CurrentLap);
        {{- else if command.command == "total" }}
        Assert.Equal({{ command.expected | to_timespan }}, stopwatch.Total);
        {{- else if command.command == "previousLaps" }}
        {{- if command.expected.empty? }}
        Assert.Empty(stopwatch.PreviousLaps);
        {{ else }}
        Assert.Equal([{{- for previousLap in command.expected }}{{ previousLap | to_timespan }}{{ if !for.last }}, {{ end }}{{ end -}}], stopwatch.PreviousLaps);
        {{ end -}}
        {{- else if command.command == "advanceTime" }}
        timeProvider.Advance({{ command.by | to_timespan }});
        {{- else }}
        {{- if command.expected && command.expected.error }}
        Assert.Throws<InvalidOperationException>(() => stopwatch.{{ command.command | pascalize }}());
        {{ else }}
        stopwatch.{{ command.command | pascalize }}();
        {{ end -}}
        {{ end -}}
        {{ end -}}
    }
    {{ end -}}
}

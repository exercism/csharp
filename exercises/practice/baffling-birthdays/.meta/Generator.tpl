{{ func to_dateonly
    parts = string.split $0 "-"
    year = parts[0] | string.to_int
    month = parts[1] | string.to_int
    day = parts[2] | string.to_int        
    $"new({year}, {month}, {day})"
end }}

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.property == "sharedBirthday" }}
        DateOnly[] birthdates = [
            {{- for birthdate in test.input.birthdates }}
            {{ birthdate | to_dateonly }}{{- if !for.last }},{{ end -}}
            {{ end }}
        ];
        Assert.{{ test.expected ? "True" : "False" }}({{ testedClass }}.{{ test.testedMethod }}(birthdates));
        {{- else if test.property == "randomBirthdates" }}
            {{-if test.expected.years }}
            var uniqueRandomYears = {{ testedClass }}.{{ test.testedMethod }}(50)
                .Select(birthdate => birthdate.Year)
                .ToHashSet();
            Assert.All(uniqueRandomYears, year => Assert.False(DateTime.IsLeapYear(year)));
            {{- else if test.expected.months }}
            var uniqueRandomMonths = {{ testedClass }}.{{ test.testedMethod }}(100)
                .Select(birthdate => birthdate.Month)
                .ToHashSet();
            Assert.Equal(12, uniqueRandomMonths.Count);
            {{- else if test.expected.days }}
            var uniqueRandomDays = {{ testedClass }}.{{ test.testedMethod }}(300)
                .Select(birthdate => birthdate.Day)
                .ToHashSet();
            Assert.Equal(31, uniqueRandomDays.Count);
            {{- else }}
            for (var count = 1; count < 10; count++)
            {
                var randomBirthdates = {{ testedClass }}.{{ test.testedMethod }}(count);
                Assert.Equal(count, randomBirthdates.Length);
            }
            {{ end -}}
        {{- else if test.property == "estimatedProbabilityOfSharedBirthday" }}
        Assert.Equal({{ test.expected }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.groupSize }}), tolerance: 1.0);
        {{ end -}}
    }
    {{ end -}}
}
